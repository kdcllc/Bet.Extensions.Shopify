namespace Bet.Extensions.Shopify.Abstractions;

public static class ShopifyHeaders
{
    public const string WebhookTopic = "X-Shopify-Topic";
    public const string HmacSha256 = "X-Shopify-Hmac-Sha256";
    public const string ShopDomain = "X-Shopify-Shop-Domain";
    public const string ApiVersion = "X-Shopify-API-Version";
    public const string WebhookId = "X-Shopify-Webhook-Id";
}
