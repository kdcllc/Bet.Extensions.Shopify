using System;

namespace Bet.Extensions.Shopify.Abstractions.Options
{
    public class ShopifyOptions
    {
        /// <summary>
        /// The Shopify Shop Name.
        /// </summary>
        public string ShopName { get; set; } = "custom-shop";

        /// <summary>
        /// The url for the Shopify Store.
        /// </summary>
        public Uri ShopUri => new ($"https://{ShopName}.myshopify.com");

        /// <summary>
        /// The url with the version for Shopify Store.
        /// </summary>
        public Uri ShopAdminWithVersionUri => new ($"{ShopUri}admin/api/{Version}/");

        /// <summary>
        /// The Shopify Admin API url.
        /// </summary>
        public Uri ShopAdminUri => new ($"{ShopUri}admin/api/");

        /// <summary>
        /// The specific version for the Api.
        /// </summary>
        public string Version { get; set; } = "2021-07";

        /// <summary>
        /// Shopify Acces Token. SharedSecret.
        /// X-Shopify-Access-Token.
        /// </summary>
        public string? ShopAccessToken { get; set; }

        /// <summary>
        /// Shopify Api Key.
        /// </summary>
        public string? ApiKey { get; set; }

        /// <summary>
        /// Timeout for the HttpRequests.
        /// </summary>
        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(300);

        /// <summary>
        /// Retry and Await policy.
        /// </summary>
        public ResilienceOptions ResilienceOptions { get; set; } = new ();
    }
}
