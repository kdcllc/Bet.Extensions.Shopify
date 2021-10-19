namespace Bet.Extensions.Shopify.Models.Orders;

public class RefundDutyType
{
    /// <summary>
    /// The unique identifier of the duty.
    /// </summary>
    [JsonPropertyName("duty_id")]
    public long? DutyId { get; set; }

    /// <summary>
    /// <para>Specifies how you want the duty refunded. Valid values:</para>
    /// <para>FULL: Refunds all the duties associated with a duty ID. You do not need to include refund line items if you are using the full refund type.</para>
    /// <para>PROPORTIONAL: Refunds duties in proportion to the line item quantity that you want to refund. If you choose the proportional refund type, then you must also pass the refund line items to calculate the portion of duties to refund.</para>
    /// </summary>
    [JsonPropertyName("refund_type")]
    public string? RefundType { get; set; }
}
