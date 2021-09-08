using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Orders
{
    /// <summary>
    /// <para> Information about the browser that the customer used when they placed their order.</para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/orders/order#properties-2021-07"/>.</para>
    /// </summary>
    public class ClientDetails
    {
        /// <summary>
        /// The languages and locales that the browser understands.
        /// </summary>
        [JsonPropertyName("accept_language")]
        public string? AcceptLanguage { get; set; }

        /// <summary>
        /// The browser screen height in pixels, if available.
        /// </summary>
        [JsonPropertyName("browser_height")]
        public int? BrowserHeight { get; set; }

        /// <summary>
        /// The browser IP address.
        /// </summary>
        [JsonPropertyName("browser_ip")]
        public string? BrowserIp { get; set; }

        /// <summary>
        /// The browser screen width in pixels, if available.
        /// </summary>
        [JsonPropertyName("browser_width")]
        public int? BrowserWidth { get; set; }

        /// <summary>
        /// A hash of the session.
        /// </summary>
        [JsonPropertyName("session_hash")]
        public string? SessionHash { get; set; }

        /// <summary>
        /// Details of the browsing client, including software and operating versions.
        /// </summary>
        [JsonPropertyName("user_agent")]
        public string? UserAgent { get; set; }
    }
}
