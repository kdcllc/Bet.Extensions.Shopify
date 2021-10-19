namespace Bet.Extensions.Shopify.Models;

/// <summary>
/// <para>A list of discounts applied to the order and checkout.</para>
/// <para>
/// <code>
///  "discount_codes": [
///  {
///  "code": "SPRING30",
///  "amount": "30.00",
///  "type": "fixed_amount"
///  }
///  ]
/// </code>
/// </para>
/// </summary>
public class DiscountCode
{
    /// <summary>
    /// <para>The amount that's deducted from the order total.</para>
    /// <para>When you create an order, this value is the percentage or monetary amount to deduct.</para>
    /// <para>After the order is created, this property returns the calculated amount.</para>
    /// <para>
    /// <code>
    ///  "amount": "30.00"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    /// <summary>
    /// <para>When the associated discount application is of type code, this property returns the discount code that was entered at checkout.</para>
    /// <para>Otherwise this property returns the title of the discount that was applied.</para>
    /// <para>
    /// <code>
    ///  "code": "SPRING30"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// <para>The type of discount. Default value: fixed_amount. Valid values:</para>
    /// <para>fixed_amount: Applies amount as a unit of the store's currency. For example, if amount is 30 and the store's currency is USD, then 30 USD is deducted from the order total when the discount is applied.</para>
    /// <para>percentage: Applies a discount of amount as a percentage of the order total.</para>
    /// <para>shipping: Applies a free shipping discount on orders that have a shipping rate less than or equal to amount. For example, if amount is 30, then the discount will give the customer free shipping for any shipping rate that is less than or equal to $30.</para>
    /// <para>
    /// <code>
    ///  "type": "fixed_amount"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
