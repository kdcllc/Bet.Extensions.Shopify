using System;
using System.Text.Json.Serialization;

using Bet.Extensions.Shopify.Models.Products;

namespace Bet.Extensions.Shopify.Models.Queries.Products
{
    /// <summary>
    /// <para>Query Shopify for <see cref="CustomCollection"/> endpoint.</para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/products/customcollection#endpoints-2021-07"/>.</para>
    /// </summary>
    public class CustomCollectionCountQuery
    {
        /// <summary>
        /// Count custom collections with given title.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Count custom collections with given title.
        /// </summary>
        [JsonPropertyName("product_id")]
        public long? ProductId { get; set; }

        /// <summary>
        /// Return products created after a specified date. (format: 2014-04-25T16:15:47-04:00).
        /// </summary>
        [JsonPropertyName("created_at_min")]
        public DateTimeOffset? CreatedAtMin { get; set; }

        /// <summary>
        /// Return products created before a specified date. (format: 2014-04-25T16:15:47-04:00).
        /// </summary>
        [JsonPropertyName("created_at_max")]
        public DateTimeOffset? CreatedAtMax { get; set; }

        /// <summary>
        /// Return products last updated after a specified date. (format: 2014-04-25T16:15:47-04:00).
        /// </summary>
        [JsonPropertyName("updated_at_min")]
        public DateTimeOffset? UpdatedAtMin { get; set; }

        /// <summary>
        /// Return products last updated before a specified date. (format: 2014-04-25T16:15:47-04:00).
        /// </summary>
        [JsonPropertyName("updated_at_max")]
        public DateTimeOffset? UpdatedAtMax { get; set; }

        /// <summary>
        /// <para>
        ///     Return Custom Collection by their published status.
        /// </para>
        /// <para>
        /// (default: any)
        /// published: Return only published Custom Collections.
        /// unpublished: Return only unpublished Custom Collections.
        /// any: Return all Custom Collections.
        /// </para>
        /// </summary>
        [JsonPropertyName("published_status")]
        public string? PublishedStatus { get; set; }
    }
}
