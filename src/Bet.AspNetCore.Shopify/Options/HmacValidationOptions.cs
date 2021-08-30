namespace Bet.AspNetCore.Shopify.Options
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
        /// The value assigned by the webhook.
        /// </summary>
        public string ShopifySharedToken { get; set; } = string.Empty;

        /// <summary>
        /// Enable or disable verification.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Webhook path to validate.
        /// </summary>
        public string WebHookPath { get; set; } = string.Empty;
    }
}
