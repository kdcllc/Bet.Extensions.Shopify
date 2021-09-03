using Bet.AspNetCore.Shopify.Middleware.Hmac;
using Bet.AspNetCore.Shopify.Middleware.Webhooks;

namespace Microsoft.AspNetCore.Builder
{
    public static class ShopifyAspNetCoreBuilderExtensions
    {
        /// <summary>
        /// Use HMAC Shopify validation based on the shared key provided by the webhook.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseShopifyHmacValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HmacValidationMiddleware>();
        }

        /// <summary>
        /// Use Shopify Webhook Middleware.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseShopifyWebhooks(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebhookMiddleware>();
        }
    }
}
