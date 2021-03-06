using Bet.Extensions.Shopify.Models.Fulfillments;

namespace Bet.Extensions.Shopify.Models.Queries.Fulfillments;

/// <summary>
/// <para>Query Shopify for <see cref="Fulfillment"/> endpoint.</para>
/// <para><see href="https://shopify.dev/api/admin/rest/reference/shipping-and-fulfillment/fulfillment#endpoints-2021-07"/>.</para>
/// </summary>
public class FulfillmentQuery : PageInfoQuery
{
    /// <summary>
    /// A comma-separated list of fields to include in the response.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<string>? Fields { get; set; }

    /// <summary>
    /// Restrict results to after the specified ID.
    /// </summary>
    [JsonPropertyName("since_id")]
    public long? SinceId { get; set; }

    /// <summary>
    /// Return created after a specified date. (format: 2014-04-25T16:15:47-04:00).
    /// </summary>
    [JsonPropertyName("created_at_min")]
    public DateTimeOffset? CreatedAtMin { get; set; }

    /// <summary>
    /// Return created before a specified date. (format: 2014-04-25T16:15:47-04:00).
    /// </summary>
    [JsonPropertyName("created_at_max")]
    public DateTimeOffset? CreatedAtMax { get; set; }

    /// <summary>
    /// Return updated after a specified date. (format: 2014-04-25T16:15:47-04:00).
    /// </summary>
    [JsonPropertyName("updated_at_min")]
    public DateTimeOffset? UpdatedAtMin { get; set; }

    /// <summary>
    /// Return updated before a specified date. (format: 2014-04-25T16:15:47-04:00).
    /// </summary>
    [JsonPropertyName("updated_at_max")]
    public DateTimeOffset? UpdatedAtMax { get; set; }
}
