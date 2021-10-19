using Bet.Extensions.Shopify.Models.Products;

namespace Bet.Extensions.Shopify.Models.Queries.Products;

/// <summary>
/// <para>Query Shopify for <see cref="CustomCollection"/> endpoint.</para>
/// <para><see href="https://shopify.dev/api/admin/rest/reference/products/customcollection#endpoints-2021-07"/>.</para>
/// </summary>
public class CustomCollectionQuery : CustomCollectionCountQuery
{
    /// <summary>
    /// Retrieve only those specified by a comma-separated list of order IDs.
    /// </summary>
    [JsonPropertyName("ids")]
    public IEnumerable<long>? Ids { get; set; }

    /// <summary>
    /// Restrict results to after the specified ID.
    /// </summary>
    [JsonPropertyName("since_id")]
    public long? SinceId { get; set; }

    /// <summary>
    /// Filter by custom collection handle.
    /// </summary>
    [JsonPropertyName("handle")]
    public string? Handle { get; set; }

    /// <summary>
    /// Return only certain fields specified by a comma-separated list of field names.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<string>? Fields { get; set; }
}
