using Bet.AspNetCore.Shopify.OAuth;
using Bet.AspNetCore.Shopify.OAuth.Options;

using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Authentication;

public static class AuthenticationBuilderExtensions
{
    /// <summary>
    /// Adds Shopify Authentication.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="configure"></param>
    /// <param name="scheme"></param>
    /// <param name="caption"></param>
    /// <returns></returns>
    public static AuthenticationBuilder AddShopify(
        this AuthenticationBuilder builder,
        Action<OAuthAppOptions> configure,
        string scheme = "Shopify",
        string caption = "Shopify")
    {
        return builder.AddOAuth<OAuthAppOptions, OAuthAppHandler>(scheme, caption, configure);
    }
}
