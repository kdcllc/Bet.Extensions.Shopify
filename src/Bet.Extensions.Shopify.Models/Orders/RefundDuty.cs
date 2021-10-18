namespace Bet.Extensions.Shopify.Models.Orders;

public class RefundDuty
{
    /// <summary>
    /// Duty Id.
    /// </summary>
    [JsonPropertyName("duty_id")]
    public long? DutyId { get; set; }

    /// <summary>
    /// Amounts.
    /// </summary>
    [JsonPropertyName("amount_set")]
    public MoneyBag? AmountSet { get; set; }
}
