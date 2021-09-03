using System.Text.Json.Serialization;

using Bet.Extensions.Shopify.Models.Products;

namespace Bet.Extensions.Shopify.Models.Queries.Products
{
    /// <summary>
    /// <para>Query Shopify for <see cref="Collect"/> endpoint.</para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/products/collect#endpoints-2021-07"/>.</para>
    /// </summary>
    public class CollectQuery : FieldsQuery
    {
        /// <summary>
        /// <para>The number of items which should be returned.</para>
        /// <para>Default is 50, maximum is 250.</para>
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Return only products after the specified ID.
        /// </summary>
        [JsonPropertyName("since_id")]
        public long? SinceId { get; set; }
    }
}
