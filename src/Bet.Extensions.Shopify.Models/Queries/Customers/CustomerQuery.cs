using Bet.Extensions.Shopify.Models.Customers;

namespace Bet.Extensions.Shopify.Models.Queries.Customers;

/// <summary>
/// <para>Query Shopify for <see cref="Customer"/> endpoint.</para>
/// <para><see href="https://shopify.dev/api/admin/rest/reference/customers/customer#endpoints-2021-07"/>.</para>
///
/// <code>
/// GET /admin/api/2021-07/customers.json?since_id=207119551
/// GET /admin/api/2021-07/customers.json?updated_at_min=2021-06-30 19:28:10
/// GET /admin/api/2021-07/customers.json?ids=207119551,5122804940878
/// </code>
/// </summary>
public class CustomerQuery : PageInfoQuery
{
    /// <summary>
    /// Restrict results to customers specified by a comma-separated list of IDs.
    /// </summary>
    [JsonPropertyName("ids")]
    public IEnumerable<long>? Ids { get; set; }

    /// <summary>
    /// Restrict results to those after the specified ID.
    /// </summary>
    [JsonPropertyName("since_id")]
    public long? SinceId { get; set; }

    /// <summary>
    /// Show customers created after a specified date.
    /// (format: 2014-04-25T16:15:47-04:00).
    /// </summary>
    [JsonPropertyName("created_at_min")]
    public DateTimeOffset? CreatedAtMin { get; set; }

    /// <summary>
    /// Show customers created before a specified date.
    /// (format: 2014-04-25T16:15:47-04:00).
    /// </summary>
    [JsonPropertyName("created_at_max")]
    public DateTimeOffset? CreatedAtMax { get; set; }

    /// <summary>
    /// Show customers last updated after a specified date.
    /// (format: 2014-04-25T16:15:47-04:00).
    /// </summary>
    [JsonPropertyName("updated_at_min")]
    public DateTimeOffset? UpdatedAtMin { get; set; }

    /// <summary>
    /// Show customers last updated before a specified date.
    /// (format: 2014-04-25T16:15:47-04:00).
    /// </summary>
    [JsonPropertyName("updated_at_max")]
    public DateTimeOffset? UpdatedAtMax { get; set; }

    /// <summary>
    /// Return only certain fields specified by a comma-separated list of field names.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<string>? Fields { get; set; }
}
