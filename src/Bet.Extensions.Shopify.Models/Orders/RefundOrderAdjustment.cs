namespace Bet.Extensions.Shopify.Models.Orders;

public class RefundOrderAdjustment : BaseModel
{
    /// <summary>
    /// The unique identifier of the order.
    /// </summary>
    [JsonPropertyName("order_id")]
    public long? OrderId { get; set; }

    /// <summary>
    /// The unique identifier of the refund.
    /// </summary>
    [JsonPropertyName("refund_id")]
    public long? RefundId { get; set; }

    /// <summary>
    /// The amount refunded (it is negative and does not include tax).
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }

    /// <summary>
    /// The tax amount refunded (negative).
    /// </summary>
    [JsonPropertyName("tax_amount")]
    public decimal? TaxAmount { get; set; }

    /// <summary>
    /// The type of adjustment. Values include "refund_discrepancy", "shipping_refund".
    /// </summary>
    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    /// <summary>
    /// Reason for the refund.
    /// </summary>
    public string? Reason { get; set; }

    /// <summary>
    /// The amount of the order adjustment in shop and presentment currencies.
    /// </summary>
    [JsonPropertyName("amount_set")]
    public MoneyBag? AmountSet { get; set; }

    /// <summary>
    /// The tax amount of the order adjustment in shop and presentment currencies.
    /// </summary>
    [JsonPropertyName("tax_amount_set")]
    public MoneyBag? TaxAmountSet { get; set; }
}
