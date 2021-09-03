using System.Collections.Generic;
using System.Text.Json.Serialization;

using Bet.Extensions.Shopify.Models.Products;

namespace Bet.Extensions.Shopify.Models.Queries.Products
{
    /// <summary>
    /// <para>Query Shopify <see cref="ProductVariant"/> endpoint.</para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/products/product-variant#endpoints-2021-07"/>.</para>
    /// </summary>
    public class ProductVariantQuery : FieldsQuery
    {
        /// <summary>
        /// <para>The number of items which should be returned.</para>
        /// <para>Default is 50, maximum is 250.</para>
        /// </summary>
        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// Restrict results to after the specified ID.
        /// </summary>
        [JsonPropertyName("since_id")]
        public long? SinceId { get; set; }

        [JsonPropertyName("presentment_currencies")]
        public IEnumerable<string>? PresentmentCurrencies { get; set; }
    }
}
