using Bet.Extensions.Shopify.Models.Products;

namespace Bet.Extensions.Shopify.Models.Queries.Products;

/// <summary>
/// Query Shopify for <see cref="ProductImage"/> endpoint.
/// <see href="https://shopify.dev/api/admin/rest/reference/products/product-image#endpoints-2021-07"/>.
/// </summary>
public class ProductImageQuery : ProductImageCountQuery
{
    /// <summary>
    /// Return only certain fields specified by a comma-separated list of field names.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<string>? Fields { get; set; }
}
