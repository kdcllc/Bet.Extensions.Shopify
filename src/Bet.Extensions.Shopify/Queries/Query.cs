using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Queries
{
    public class Query
    {
        /// <summary>
        /// A unique ID used to access a page of results. Must be present to list more than the first page of results.
        /// </summary>
        [JsonPropertyName("page_info")]
        public string? PageInfo { get; set; }

        /// <summary>
        /// The number of items which should be returned. Default is 50, maximum is 250.
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Comma-separated list of which fields to show in the results. This parameter only works for some endpoints.
        /// </summary>
        [JsonPropertyName("fields")]
        public string? Fields { get; set; }
    }
}
