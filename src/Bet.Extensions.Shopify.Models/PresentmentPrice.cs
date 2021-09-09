using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models
{
    public class PresentmentPrice
    {
        /// <summary>
        /// The price of the product variant.
        /// </summary>
        [JsonPropertyName("price")]
        public MoneyBag? Price { get; set; }

        /// <summary>
        /// The competitors prices for the same item.
        /// </summary>
        [JsonPropertyName("compare_at_price")]
        public MoneyBag? CompareAtPrice { get; set; }
    }
}
