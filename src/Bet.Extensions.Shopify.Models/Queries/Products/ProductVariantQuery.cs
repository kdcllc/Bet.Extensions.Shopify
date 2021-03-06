using Bet.Extensions.Shopify.Models.Products;

namespace Bet.Extensions.Shopify.Models.Queries.Products;

/// <summary>
/// <para>Query Shopify <see cref="ProductVariant"/> endpoint.</para>
/// <para><see href="https://shopify.dev/api/admin/rest/reference/products/product-variant#endpoints-2021-07"/>.</para>
/// </summary>
public class ProductVariantQuery : PageInfoQuery
{
    /// <summary>
    /// Restrict results to after the specified ID.
    /// </summary>
    [JsonPropertyName("since_id")]
    public long? SinceId { get; set; }

    [JsonPropertyName("presentment_currencies")]
    public IEnumerable<string>? PresentmentCurrencies { get; set; }

    /// <summary>
    /// Return only certain fields specified by a comma-separated list of field names.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<string>? Fields { get; set; }
}
