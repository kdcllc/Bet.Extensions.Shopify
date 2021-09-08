using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models
{
    public class Receipt
    {
        /// <summary>
        /// Whether the fulfillment was a testcase.
        /// </summary>
        [JsonPropertyName("testcase")]
        public bool? TestCase { get; set; }

        /// <summary>
        /// The authorization code.
        /// </summary>
        [JsonPropertyName("authorization")]
        public string? Authorization { get; set; }
    }
}
