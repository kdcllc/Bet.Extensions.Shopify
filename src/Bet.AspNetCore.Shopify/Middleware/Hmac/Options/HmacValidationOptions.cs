using System.Collections.Generic;

namespace Bet.AspNetCore.Shopify.Middleware.Hmac.Options
{
    /// <summary>
    /// Hmac validation middleware options configurations.
    /// </summary>
    public class HmacValidationOptions
    {
        /// <summary>
        /// The default Shopify Header.
        /// </summary>
        public string ShopifyHmacHeaderName { get; set; } = "X-Shopify-Hmac-Sha256";

        /// <summary>
        /// The value assigned by the webhook upon creation of the webhook.
        /// </summary>
        public string SharedSecret { get; set; } = string.Empty;

        /// <summary>
        /// Enable or disable verification.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Webhook path to validate.
        /// </summary>
        public IList<string> WebHookPaths { get; set; } = new List<string>();
    }
}
