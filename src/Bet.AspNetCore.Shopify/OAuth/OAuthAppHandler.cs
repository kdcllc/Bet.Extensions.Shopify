using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

using Bet.AspNetCore.Shopify.OAuth.Options;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bet.AspNetCore.Shopify.OAuth
{
    public class OAuthAppHandler : OAuthHandler<OAuthAppOptions>
    {
        private const string ShopifyScopeClaimType = "urn:shopify:scope";

        public OAuthAppHandler(
            IOptionsMonitor<OAuthAppOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        /// <inheritdoc />
        protected override async Task<AuthenticationTicket> CreateTicketAsync(
            ClaimsIdentity identity,
            AuthenticationProperties properties,
            OAuthTokenResponse tokens)
        {
            var uri = string.Format(CultureInfo.InvariantCulture, Options.UserInformationEndpoint, properties.Items[OAuthConstants.ShopNameProperty]);

            using var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Add("X-Shopify-Access-Token", tokens.AccessToken);

            using var response = await Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, Context.RequestAborted);
            if (!response.IsSuccessStatusCode)
            {
                Logger.LogError(
                                "An error occurred while retrieving the user profile: the remote server " +
                                "returned a {Status} response with the following payload: {Headers} {Body}.",
                                /* Status: */ response.StatusCode,
                                /* Headers: */ response.Headers.ToString(),
                                /* Body: */ await response.Content.ReadAsStringAsync(Context.RequestAborted));

                throw new HttpRequestException("An error occurred while retrieving the shop profile.");
            }

            using var payload = JsonDocument.Parse(await response.Content.ReadAsStringAsync(Context.RequestAborted));

            // In Shopify, the customer can modify the scope given to the app. Apps should verify
            // that the customer is allowing the required scope.
            var actualScope = tokens.Response.RootElement.GetString("scope") ?? string.Empty;
            var isPersistent = true;

            // If the request was for a "per-user" (i.e. no offline access)
            if (tokens.Response.RootElement.TryGetProperty("expires_in", out var expiresInProperty))
            {
                isPersistent = false;

                if (expiresInProperty.TryGetInt32(out var expiresIn))
                {
                    var expires = Clock.UtcNow.AddSeconds(expiresIn);
                    identity.AddClaim(new Claim(ClaimTypes.Expiration, expires.ToString("O", CultureInfo.InvariantCulture), ClaimValueTypes.DateTime));
                }

                actualScope = tokens.Response.RootElement.GetString("associated_user_scope") ?? string.Empty;

                var userData = tokens.Response.RootElement.GetString("associated_user") ?? string.Empty;
                identity.AddClaim(new Claim(ClaimTypes.UserData, userData));
            }

            identity.AddClaim(new Claim(ClaimTypes.IsPersistent, isPersistent.ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Boolean));
            identity.AddClaim(new Claim(ShopifyScopeClaimType, actualScope));

            var principal = new ClaimsPrincipal(identity);
            var context = new OAuthCreatingTicketContext(principal, properties, Context, Scheme, Options, Backchannel, tokens, payload.RootElement);
            context.RunClaimActions();

            await Options.Events.CreatingTicket(context);

            return new AuthenticationTicket(context.Principal!, context.Properties, Scheme.Name);
        }

        /// <inheritdoc />
        protected override string FormatScope()
        {
            return string.Join(',', Options.Scope);
        }

        /// <inheritdoc />
        protected override string BuildChallengeUrl(AuthenticationProperties properties, string redirectUri)
        {
            if (!properties.Items.TryGetValue(OAuthConstants.ShopNameProperty, out var shopName)
                && string.IsNullOrEmpty(shopName))
            {
                var message = $"Shopify provider AuthenticationProperties must contain {OAuthConstants.ShopNameProperty}.";

                Logger.LogError(message);
                throw new InvalidOperationException(message);
            }

            var uri = string.Format(CultureInfo.InvariantCulture, Options.AuthorizationEndpoint, shopName);

            // Get the permission scope, which can either be set in options or overridden in AuthenticationProperties.
            if (!properties.Items.TryGetValue(OAuthConstants.ScopeProperty, out var scope))
            {
                scope = FormatScope();
            }

            var url = QueryHelpers.AddQueryString(uri, new Dictionary<string, string?>()
            {
                ["client_id"] = Options.ClientId,
                ["scope"] = scope,
                ["redirect_uri"] = redirectUri,
                ["state"] = Options.StateDataFormat.Protect(properties)
            });

            // If we're requesting a per-user, online only, token, add the grant_options query param.
            if (properties.Items.TryGetValue(OAuthConstants.GrantOptionsProperty, out var grantOptions) &&
                grantOptions == OAuthConstants.PerUserProperty)
            {
                url = QueryHelpers.AddQueryString(url, "grant_options[]", OAuthConstants.PerUserProperty);
            }

            return url;
        }

        /// <inheritdoc />
        protected override async Task<OAuthTokenResponse> ExchangeCodeAsync(OAuthCodeExchangeContext context)
        {
            string shopDns;

            try
            {
                var shopValue = Context.Request.Query["shop"];
                var stateValue = Context.Request.Query["state"];

                var shop = shopValue.ToString();

                // Shop name must end with myshopify.com
                if (!shop.EndsWith(".myshopify.com", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("Shop parameter is malformed. It should end with .myshopify.com");
                }

                // Strip out the "myshopify.com" suffix
                shopDns = shop.Split('.')[0];

                // Verify that the shop name encoded in "state" matches the shop name we used to
                // request the token. This probably isn't necessary, but it's an easy extra verification.
                var authenticationProperties = Options.StateDataFormat.Unprotect(stateValue);

                var shopNamePropertyValue = authenticationProperties?.Items[OAuthConstants.ShopNameProperty];

                if (!string.Equals(shopNamePropertyValue, shopDns, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("Received shop name does not match the shop name specified in the authentication request.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "An error occurred while exchanging tokens: {ErrorMessage}", ex.Message);
                return OAuthTokenResponse.Failed(ex);
            }

            var uri = string.Format(CultureInfo.InvariantCulture, Options.TokenEndpoint, shopDns);

            using var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            var parameters = new Dictionary<string, string>
            {
                ["client_id"] = Options.ClientId,
                ["client_secret"] = Options.ClientSecret,
                ["code"] = context.Code
            };

            request.Content = new FormUrlEncodedContent(parameters!);

            using var response = await Backchannel.SendAsync(request, Context.RequestAborted);

            if (!response.IsSuccessStatusCode)
            {
                Logger.LogError(
                                "An error occurred while retrieving an access token: the remote server returned a {Status} response with the following payload: {Headers} {Body}.",
                                /* Status: */ response.StatusCode,
                                /* Headers: */ response.Headers.ToString(),
                                /* Body: */ await response.Content.ReadAsStringAsync(Context.RequestAborted));

                return OAuthTokenResponse.Failed(new Exception("An error occurred while retrieving an access token."));
            }

            var payload = JsonDocument.Parse(await response.Content.ReadAsStringAsync(Context.RequestAborted));
            return OAuthTokenResponse.Success(payload);
        }
    }
}
