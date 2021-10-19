namespace Bet.Extensions.Shopify.Models.Orders;

/// <summary>
/// <para>The Shopify API lets you do the following with the Refund resource. More detailed versions of these general actions may be a available:</para>
/// <para>
/// GET /admin/api/2021-07/orders/{order_id}/refunds.json
/// Retrieves a list of refunds for an order.
/// </para>
/// <para>
/// GET /admin/api/2021-07/orders/{order_id}/refunds/{refund_id}.json
/// Retrieves a specific refund.
/// </para>
/// <para>
/// POST /admin/api/2021-07/orders/{order_id}/refunds/calculate.json
/// Calculates a refund.
/// </para>
/// <para>
/// POST /admin/api/2021-07/orders/{order_id}/refunds.json
/// Creates a refund.
/// </para>
/// <para><see href="https://shopify.dev/api/admin/rest/reference/orders/refund#properties-2021-07"/>.</para>
/// </summary>
public class Refund : BaseModel
{
    /// <summary>
    /// The unique identifier of the order.
    /// </summary>
    [JsonPropertyName("order_id")]
    public long? OrderId { get; set; }

    /// <summary>
    /// <para>The date and time (ISO 8601 format) when the refund was created.</para>
    /// <para>
    /// <code>
    /// "created_at": "2008-01-10T11:00:00-05:00"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// <para>A list of order adjustments attached to the refund.
    /// Order adjustments are generated to account for refunded shipping costs and differences between calculated and actual refund amounts.</para>
    /// <para>
    /// <code>
    /// "order_adjustments": [
    /// {
    /// "id": 4221763620,
    /// "order_id": 171016912932,
    /// "refund_id": 8244756516,
    /// "amount": "-8.00",
    /// "tax_amount": "0.00",
    /// "kind": "shipping_refund",
    /// "reason": "Shipping refund",
    /// "amount_set": {
    /// "shop_money": {
    /// "amount": 10.99,
    /// "currency_code": "USD"
    /// },
    /// "presentment_money": {
    /// "amount": 12.95,
    /// "currency_code": "CAD"
    /// }
    /// },
    /// "tax_amount_set": {
    /// "shop_money": {
    /// "amount": 1.67,
    /// "currency_code": "USD"
    /// },
    /// "presentment_money": {
    /// "amount": 2.32,
    /// "currency_code": "CAD"
    /// }
    /// }
    /// }
    /// ]
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("order_adjustments")]
    public IEnumerable<RefundOrderAdjustment>? OrderAdjustments { get; set; }

    /// <summary>
    /// <para>The date and time (ISO 8601 format) when the refund was imported.
    /// This value can be set to a date in the past when importing from other systems.
    /// If no value is provided, then it will be auto-generated as the current time in Shopify.</para>
    /// <para>
    /// <code>
    /// "processed_at": "2007-01-10T11:00:00-05:00"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("processed_at")]
    public DateTimeOffset? ProcessedAt { get; set; }

    /// <summary>
    /// <para>An optional note attached to a refund.</para>
    /// <para>
    /// <code>
    /// "note": "Item was damaged during shipping"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// <para>The list of <see cref="RefundLineItem"/> objects.</para>
    /// <para>
    /// <code>
    /// "refund_line_items": []
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("refund_line_items")]
    public IEnumerable<RefundLineItem>? RefundLineItems { get; set; }

    /// <summary>
    /// <para>A list of transactions involved in the refund. For more information, see the Transaction resource.</para>
    /// <para>
    /// <code>
    ///    "transactions": [
    ///    {
    ///    "id": 179259969,
    ///    "order_id": 450789469,
    ///    "amount": "209.00",
    ///    "kind": "refund",
    ///    "gateway": "shopify_payments",
    ///    "status": "success",
    ///    "message": null,
    ///    "created_at": "2005-08-05T12:59:12-04:00",
    ///    "test": false,
    ///    "authorization": "authorization-key",
    ///    "currency": "USD",
    ///    "location_id": null,
    ///    "user_id": null,
    ///    "parent_id": 801038806,
    ///    "device_id": null,
    ///    "receipt": {},
    ///    "error_code": null,
    ///    "source_name": "web"
    ///    }
    ///    ]
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("transactions")]
    public IEnumerable<Transaction>? Transactions { get; set; }

    /// <summary>
    /// <para>A list of duties that have been returned as part of the refund.</para>
    /// <para>
    /// <code>
    /// "duties": [
    /// {
    /// "duty_id": 1,
    /// "amount_set": {
    /// "shop_money": {
    /// "amount": "9.83",
    /// "currency_code": "CAD"
    /// },
    /// "presentment_money": {
    /// "amount": "9.83",
    /// "currency_code": "CAD"
    /// }
    /// }
    /// }
    /// ]        /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("duties")]
    public IEnumerable<RefundDuty>? Duties { get; set; }

    /// <summary>
    /// <para>A list of refunded duties.</para>
    /// <para>
    /// <code>
    ///  "refund_duties": [
    ///  {
    ///  "duty_id": 1,
    ///  "refund_type": "FULL"
    ///  }
    ///  ]
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("refund_duties")]
    public IEnumerable<RefundDutyType>? RefundDuties { get; set; }

    /// <summary>
    /// <para>Whether to add the line items back to the store's inventory.</para>
    /// <para>
    /// <code>
    /// "restock": true
    /// </code>
    /// </para>
    /// </summary>
    [Obsolete($"Use {nameof(RefundLineItem.RestockType)} to influence how this refund affects inventory instead")]
    [JsonPropertyName("restock")]
    public bool? Restock { get; set; }

    /// <summary>
    /// <para>The unique identifier of the user who performed the refund.</para>
    /// <para>
    /// <code>
    ///  "user_id": 238478920
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("user_id")]
    public long? UserId { get; set; }

    /// <summary>
    /// <para>
    /// The three-letter code (ISO 4217 format) for the currency used for the refund.
    /// Note: Required whenever the shipping amount property is provided.
    /// </para>
    /// <para>
    /// <code>
    ///  "currency" : "USD"
    /// </code>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Used POST /admin/api/2021-07/orders/{order_id}/refunds.json.
    /// </remarks>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// <para>An optional comment that explains a discrepancy between calculated and actual refund amounts.</para>
    /// <para>Used to populate the reason property of the resulting order adjustment object attached to the refund.</para>
    /// <para>Valid values: restock, damage, customer, and other.</para>
    /// <para>
    /// <code>
    /// "discrepancy_reason" : "restock"
    /// </code>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Used POST /admin/api/2021-07/orders/{order_id}/refunds.json.
    /// </remarks>
    [JsonPropertyName("discrepancy_reason")]
    public string? DiscrepancyReason { get; set; }

    /// <summary>
    /// <para>
    /// Specify how much shipping to refund. It has the following properties:
    /// full_refund: Whether to refund all remaining shipping.
    /// </para>
    /// <para>amount: Set a specific amount to refund for shipping.Takes precedence over full_refund.</para>
    /// <para>
    /// <code>
    ///  "shipping": {
    ///  "full_refund": true
    ///  }        /// </code>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Used POST /admin/api/2021-07/orders/{order_id}/refunds.json.
    /// </remarks>
    [JsonPropertyName("shipping")]
    public RefundShipping? Shipping { get; set; }

    /// <summary>
    /// <para>Whether to send a refund notification to the customer.</para>
    /// <para>
    /// <code>
    /// "notify": true
    /// </code>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Used POST /admin/api/2021-07/orders/{order_id}/refunds.json.
    /// </remarks>
    [JsonPropertyName("notify")]
    public bool? Notify { get; set; }
}
