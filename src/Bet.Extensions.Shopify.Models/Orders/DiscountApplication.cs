namespace Bet.Extensions.Shopify.Models.Orders;

public class DiscountApplication
{
    /// <summary>
    /// <para>The discount application type. Valid values:</para>
    /// <para>manual: The discount was manually applied by the merchant(for example, by using an app or creating a draft order).</para>
    /// <para>script: The discount was applied by a Shopify Script.</para>
    /// <para>discount_code: The discount was applied by a discount code.</para>
    ///
    /// <code>
    /// "type": "manual"
    /// </code>
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// <para>The discount code that was used to apply the discount.</para>
    /// <para>Available only for discount code applications.</para>
    /// <para>
    /// <code>
    /// "code": "SUMMERSALE"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// <para>The title of the discount application, as defined by the merchant.</para>
    /// <para>Available only for manual discount applications.</para>
    /// <para>
    /// <code>
    /// "title": "custom discount"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// <para>The description of the discount application, as defined by the merchant or the Shopify Script.</para>
    /// <para>Available only for manual and script discount applications.</para>
    /// <para>
    /// <code>
    /// "description": "my scripted discount"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// <para>The value of the discount application as a decimal. This represents the intention of the discount application.</para>
    /// <para>For example, if the intent was to apply a 20% discount, then the value will be 20.0.</para>
    /// <para>If the intent was to apply a $15 discount, then the value will be 15.0.</para>
    /// <para>
    /// <code>
    ///  "value": "2.0"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// <para>The type of the value. Valid values:</para>
    /// <para>
    /// fixed_amount: A fixed amount discount value in the currency of the order.
    /// percentage: A percentage discount value.
    /// </para>
    /// <para>
    /// <code>
    ///  "value_type": "fixed_amount"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("value_type")]
    public string? ValueType { get; set; }

    /// <summary>
    /// <para>The method by which the discount application value has been allocated to entitled lines. Valid values:</para>
    /// <para>across: The value is spread across all entitled lines.</para>
    /// <para>each: The value is applied onto every entitled line.</para>
    /// <para>one: The value is applied onto a single line.</para>
    /// <para>
    /// <code>
    ///  "allocation_method": "across"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("allocation_method")]
    public string? AllocationMethod { get; set; }

    /// <summary>
    /// <para>The lines on the order, of the type defined by target_type, that the discount is allocated over. Valid values:</para>
    /// <para>all: The discount is allocated onto all lines.</para>
    /// <para>entitled: The discount is allocated only onto lines it is entitled for.</para>
    /// <para>explicit: The discount is allocated onto explicitly selected lines.</para>
    /// <para>
    /// <code>
    /// "target_selection": "all"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("target_selection")]
    public string? TargetSelection { get; set; }

    /// <summary>
    /// <para>The type of line on the order that the discount is applicable on. Valid values:</para>
    /// <para>line_item: The discount applies to line items.</para>
    /// <para>shipping_line: The discount applies to shipping lines.</para>
    /// <para>
    /// <code>
    ///  "target_type": "line_item"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("target_type")]
    public string? TargetType { get; set; }
}
