using System;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Products
{
    /// <summary>
    /// <para>
    /// POST /admin/api/2021-07/collects.json
    /// Adds a product to a custom collection.
    /// </para>
    /// <para>
    /// DELETE /admin/api/2021-07/collects/{collect_id}.json
    /// Removes a product from a collection.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/collects.json
    /// Retrieves a list of collects.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/collects/count.json
    /// Retrieves a count of collects.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/collects/{collect_id}.json
    /// Retrieves a specific collect by its ID.
    /// </para>
    /// </summary>
    public class Collect
    {
        /// <summary>
        /// "collection_id": 841564295
        /// The ID of the custom collection containing the product.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("collection_id")]
        public long CollectionId { get; set; }

        [JsonPropertyName("product_id")]
        public long ProductId { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonPropertyName("position")]
        public long Position { get; set; }

        [JsonPropertyName("sort_value")]
        public string? SortValue { get; set; }
    }
}
