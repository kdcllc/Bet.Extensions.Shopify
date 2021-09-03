using Bet.AspNetCore.Shopify.Middleware.Hmac;

namespace Microsoft.AspNetCore.Builder
{
    public static class ShopifyAspNetCoreBuilderExtensions
    {
        public static IApplicationBuilder UseShopifyHmacValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HmacValidationMiddleware>();
        }
    }
}
