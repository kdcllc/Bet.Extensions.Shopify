using System;

namespace Bet.Extensions.Shopify.Abstractions.Options
{
    public class ShopifyOptions
    {
        /// <summary>
        /// Shopify Shop Url.
        /// </summary>
        public string ShopUrl { get; set; }

        public string Version { get; set; } = "2021-07";

        /// <summary>
        /// Shopify Acces Token. SharedSecret.
        /// X-Shopify-Access-Token.
        /// </summary>
        public string ShopAccessToken { get; set; }

        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(300);

        /// <summary>
        /// Retry and Await policy.
        /// </summary>
        public ResilienceOptions ResilienceOptions { get; set; } = new();
    }
}
