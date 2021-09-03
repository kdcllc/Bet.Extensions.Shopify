using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Products
{
    public class ProductOption : BaseModel
    {
        /// <summary>
        /// The unique numeric identifier for the product.
        /// </summary>
        [JsonPropertyName("product_id")]
        public long? ProductId { get; set; }

        /// <summary>
        /// The name of the option.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The order of the product variant in the list of product variants. 1 is the first position.
        /// </summary>
        [JsonPropertyName("position")]
        public int? Position { get; set; }

        /// <summary>
        /// The values for the options.
        /// </summary>
        [JsonPropertyName("values")]
        public IEnumerable<string>? Values { get; set; }
    }
}
