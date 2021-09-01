using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Queries
{
    public class FieldsQuery
    {
        /// <summary>
        /// Return only certain fields specified by a comma-separated list of field names.
        /// </summary>
        [JsonPropertyName("fields")]
        public string? Fields { get; set; }
    }
}
