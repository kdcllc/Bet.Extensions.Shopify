using System;
using System.Text.Json.Serialization;

using Bet.Extensions.Shopify.Models.Products;

namespace Bet.Extensions.Shopify.Models.Queries.Products
{
    /// <summary>
    /// <para>Query Shopify <see cref="Product"/> endpoint.</para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/products/product#endpoints-2021-07"/>.</para>
    /// </summary>
    public class ProductCountQuery : PageInfoQuery
    {
        /// <summary>
        /// Return products by product vendor.
        /// </summary>
        [JsonPropertyName("vendor")]
        public string? Vendor { get; set; }

        /// <summary>
        /// Return products by product type.
        /// </summary>
        [JsonPropertyName("product_type")]
        public string? ProductType { get; set; }

        /// <summary>
        /// Return products by product collection ID.
        /// </summary>
        [JsonPropertyName("collection_id")]
        public long? CollectionId { get; set; }

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
        /// Return products published after a specified date. (format: 2014-04-25T16:15:47-04:00).
        /// </summary>
        [JsonPropertyName("published_at_min")]
        public DateTimeOffset? PublishedAtMin { get; set; }

        /// <summary>
        /// Return products published before a specified date. (format: 2014-04-25T16:15:47-04:00).
        /// </summary>
        [JsonPropertyName("published_at_max")]
        public DateTimeOffset? PublishedAtMax { get; set; }

        /// <summary>
        /// <para>
        ///     Return products by their published status.
        /// </para>
        /// <para>
        /// (default: any)
        /// published: Return only published products.
        /// unpublished: Return only unpublished products.
        /// any: Return all products.
        /// </para>
        /// </summary>
        [JsonPropertyName("published_status")]
        public string? PublishedStatus { get; set; }
    }
}
