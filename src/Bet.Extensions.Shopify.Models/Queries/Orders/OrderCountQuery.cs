using Bet.Extensions.Shopify.Models.Orders;

namespace Bet.Extensions.Shopify.Models.Queries.Orders;

/// <summary>
/// <para>Query Shopify <see cref="Order"/> endpoint.</para>
/// <para><see href="https://shopify.dev/api/admin/rest/reference/orders/order#endpoints-2021-07"/>.</para>
/// </summary>
public class OrderCountQuery
{
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

    /// <summary>
    /// <para>Orders of a given status.</para>
    /// <para>open: Open orders.</para>
    /// <para>closed: Closed orders.</para>
    /// <para>any: Orders of any status.</para>
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// <para>Orders of a given financial status.</para>
    /// <para>authorized: Authorized orders.</para>
    /// <para>pending: Pending orders.</para>
    /// <para>paid: Paid orders.</para>
    /// <para>refunded: Refunded orders.</para>
    /// <para>voided: Voided orders.</para>
    /// <para>any: Orders of any financial status. </para>
    /// </summary>
    [JsonPropertyName("financial_status")]
    public string? FinancialStatus { get; set; }

    /// <summary>
    /// <para>Orders of a given fulfillment status.</para>
    /// <para>(default: any).</para>
    /// <para>shipped: Orders that have been shipped. Returns orders with fulfillment_status of fulfilled.</para>
    /// <para>partial: Partially shipped orders.</para>
    /// <para>unshipped: Orders that have not yet been shipped. Returns orders with fulfillment_status of null.</para>
    /// <para>any: Orders of any fulfillment status.</para>
    /// <para>unfulfilled: Orders with fulfillment_status of null or partial.</para>
    /// </summary>
    [JsonPropertyName("fulfillment_status")]
    public string? FulfillmentStatus { get; set; }
}
