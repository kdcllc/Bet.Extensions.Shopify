using Bet.AspNetCore.Shopify.OAuth;
using Bet.Extensions.Shopify.Abstractions.Options;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ShopifyWeb.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ShopifyOptions _options;
        private readonly OAuthAuthenticationProperties _param;

        public AuthenticationController(IOptions<ShopifyOptions> options)
        {
            _options = options.Value;
            _param = new OAuthAuthenticationProperties(_options.ShopName) { RedirectUri = "/" };
        }

        [HttpPost("/signin")]
        public async Task<IActionResult> SignIn([FromForm] string provider)
        {
            // Note: the "provider" parameter corresponds to the external
            // authentication provider choosen by the user agent.
            if (string.IsNullOrWhiteSpace(provider))
            {
                return BadRequest();
            }

            if (!await HttpContext.IsProviderSupportedAsync(provider))
            {
                return BadRequest();
            }

            // Instruct the middleware corresponding to the requested external identity
            // provider to redirect the user agent to its own authorization endpoint.
            // Note: the authenticationScheme parameter must match the value configured in Startup.cs
            return Challenge(_param, provider);
        }

        [HttpGet("/signout")]
        [HttpPost("/signout")]
        public async Task<IActionResult> SignOutCurrentUser()
        {
            // Instruct the cookies middleware to delete the local cookie created
            // when the user agent is redirected from the Shopify external identity provider
            // after a successful authentication flow.
            return SignOut(_param, CookieAuthenticationDefaults.AuthenticationScheme);
        }
   }
}
