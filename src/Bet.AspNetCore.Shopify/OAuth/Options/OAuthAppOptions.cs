using System.Security.Claims;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Bet.AspNetCore.Shopify.OAuth.Options
{
    public class OAuthAppOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuthAppOptions"/> class.
        /// <see href="https://developer.okta.com/blog/2019/07/12/secure-your-aspnet-core-app-with-oauth"/>.
        /// </summary>
        public OAuthAppOptions()
        {
            ClaimsIssuer = "Shopify";
            CallbackPath = "/signin-shopify";
            AuthorizationEndpoint = "https://{0}.myshopify.com/admin/oauth/authorize";
            TokenEndpoint = "https://{0}.myshopify.com/admin/oauth/access_token";
            UserInformationEndpoint = "https://{0}.myshopify.com/admin/shop";

            ClaimActions.MapJsonSubKey(ClaimTypes.NameIdentifier, "shop", "myshopify_domain");
            ClaimActions.MapJsonSubKey(ClaimTypes.Name, "shop", "name");
            ClaimActions.MapJsonSubKey(ClaimTypes.Webpage, "shop", "domain");
            ClaimActions.MapJsonSubKey(ClaimTypes.Email, "shop", "email");
            ClaimActions.MapJsonSubKey(ClaimTypes.Country, "shop", "country_code");
            ClaimActions.MapJsonSubKey(ClaimTypes.StateOrProvince, "shop", "province_code");
            ClaimActions.MapJsonSubKey(ClaimTypes.PostalCode, "shop", "zip");
            ClaimActions.MapJsonSubKey(ClaimTypes.Locality, "shop", "primary_locale");
            ClaimActions.MapJsonSubKey("urn:shopify:plan_name", "shop", "plan_name");
            ClaimActions.MapJsonSubKey("urn:shopify:eligible_for_payments", "shop", "eligible_for_payments", ClaimValueTypes.Boolean);
            ClaimActions.MapJsonSubKey("urn:shopify:timezone", "shop", "timezone");
        }
    }
}
