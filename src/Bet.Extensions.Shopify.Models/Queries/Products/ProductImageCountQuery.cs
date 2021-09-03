using System.Text.Json.Serialization;

using Bet.Extensions.Shopify.Models.Products;

namespace Bet.Extensions.Shopify.Models.Queries.Products
{
    /// <summary>
    /// <para>Query Shopify for <see cref="ProductImage"/> endpoint.</para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/products/product-image#endpoints-2021-07"/>.</para>
    /// </summary>
    public class ProductImageCountQuery
    {
        /// <summary>
        /// Return only products after the specified ID.
        /// </summary>
        [JsonPropertyName("since_id")]
        public long? SinceId { get; set; }
    }
}
