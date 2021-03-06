using Bet.Extensions.Shopify.Models.Products;

namespace Bet.Extensions.Shopify.Models.Queries.Products;

/// <summary>
/// <para>Query Shopify for <see cref="Collect"/> endpoint.</para>
/// <para><see href="https://shopify.dev/api/admin/rest/reference/products/collect#endpoints-2021-07"/>.</para>
/// </summary>
public class CollectQuery : PageInfoQuery
{
    /// <summary>
    /// Return only products after the specified ID.
    /// </summary>
    [JsonPropertyName("since_id")]
    public long? SinceId { get; set; }

    /// <summary>
    /// Return only certain fields specified by a comma-separated list of field names.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<string>? Fields { get; set; }
}
