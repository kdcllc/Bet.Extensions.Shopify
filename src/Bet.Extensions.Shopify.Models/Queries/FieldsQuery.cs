using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Queries
{
    public class FieldsQuery
    {
        /// <summary>
        /// Return only certain fields specified by a comma-separated list of field names.
        /// </summary>
        [JsonPropertyName("fields")]
        public IEnumerable<string>? Fields { get; set; }
    }
}
