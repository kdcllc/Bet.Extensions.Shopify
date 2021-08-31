using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Queries
{
    public class ProductQuery : Query
    {
        [JsonPropertyName("vendor")]
        public string? Vendor { get; set; }

        /// <summary>
        /// Retrieve only those specified by a comma-separated list of order IDs.
        /// </summary>
        [JsonPropertyName("ids")]
        public IEnumerable<long>? Ids { get; set; }
    }
}
