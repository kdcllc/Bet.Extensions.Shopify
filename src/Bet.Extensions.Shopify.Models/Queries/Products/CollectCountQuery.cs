using System.Text.Json.Serialization;

using Bet.Extensions.Shopify.Models.Products;

namespace Bet.Extensions.Shopify.Models.Queries.Products
{
    /// <summary>
    /// <para> Query Shopify <see cref="Collect"/> endpoint.</para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/products/collect#endpoints-2021-07"/>.</para>
    /// </summary>
    public class CollectCountQuery
    {
        /// <summary>
        /// Return only Count only collects for a certain product.
                /// </summary>
        [JsonPropertyName("product_id")]
        public string? ProductId { get; set; }

        /// <summary>
        /// Return only Count only collects for a certain product.
        /// </summary>
        [JsonPropertyName("collection_id")]
        public string? CollectionId { get; set; }
    }
}
