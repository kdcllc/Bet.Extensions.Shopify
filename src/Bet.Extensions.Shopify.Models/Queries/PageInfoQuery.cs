using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Queries
{
    /// <summary>
    /// Default query parameters.
    /// </summary>
    public class PageInfoQuery
    {
        /// <summary>
        /// <para>A unique ID used to access a page of results.</para>
        /// <para>Must be present to list more than the first page of results.</para>
        /// </summary>
        [JsonPropertyName("page_info")]
        public string? PageInfo { get; set; }

        /// <summary>
        /// <para>The number of items which should be returned.</para>
        /// <para>Default is 50, maximum is 250.</para>
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }
    }
}
