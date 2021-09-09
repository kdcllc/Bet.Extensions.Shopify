using System.Collections.Generic;
using System.Text.Json.Serialization;

using Bet.Extensions.Shopify.Models.Products;

namespace Bet.Extensions.Shopify.Models.Queries.Products
{
    /// <summary>
    /// <para>Query Shopify <see cref="Product"/> endpoint.</para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/products/product#endpoints-2021-07"/>.</para>
    /// </summary>
    public class ProductQuery : ProductCountQuery
    {
        /// <summary>
        /// Retrieve only those specified by a comma-separated list of Products IDs.
        /// </summary>
        [JsonPropertyName("ids")]
        public IEnumerable<long>? Ids { get; set; }

        /// <summary>
        /// Restrict results to after the specified ID.
        /// </summary>
        [JsonPropertyName("since_id")]
        public long? SinceId { get; set; }

        /// <summary>
        /// Return products by product title.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Return only products specified by a comma-separated list of product handles.
        /// </summary>
        [JsonPropertyName("handle")]
        public string? Handle { get; set; }

        /// <summary>
        /// Return only products specified by a comma-separated list of statuses.
        ///        (default: any)
        ///     active: Return only active products.
        ///     archived: Return only archived products.
        ///     draft: Return only draft products.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Return only certain fields specified by a comma-separated list of field names.
        /// </summary>
        [JsonPropertyName("fields")]
        public string? Fields { get; set; }

        /// <summary>
        /// Return presentment prices in only certain currencies,
        /// converts to a comma-separated list of ISO 4217 currency codes.
        /// </summary>
        [JsonPropertyName("presentment_currencies")]
        public IEnumerable<string>? PresentmentCurrencies { get; set; }
    }
}
