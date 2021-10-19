using Bet.Extensions.Shopify.Models.LineItems;

namespace Bet.Extensions.Shopify.Models.Orders;

public class RefundLineItem : BaseModel
{
    /// <summary>
    /// <para>The single <see cref="LineItem"/> being returned.</para>
    /// <para>
    /// <code>
    /// "line_item": {}
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("line_item")]
    public LineItem? LineItem { get; set; }

    /// <summary>
    /// <para>The unique identifier of the refund line item.</para>
    /// <para>
    /// <code>
    /// "line_item_id": 128323456
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("line_item_id")]
    public long? LineItemId { get; set; }

    /// <summary>
    /// <para>The quantity of the associated line item that was returned.</para>
    /// <para>
    /// <code>
    /// "quantity": 2
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }

    /// <summary>
    /// <para>Tax amount refunded.</para>
    /// <para>
    /// <code>
    /// "total_tax": 2.67
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("total_tax")]
    public decimal? TotalTax { get; set; }

    /// <summary>
    /// <para>Item subtotal.</para>
    /// <para>
    /// <code>
    /// "subtotal": 10.99
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("subtotal")]
    public decimal? SubTotal { get; set; }

    /// <summary>
    /// <para>The subtotal of the refund line item in shop and presentment currencies.</para>
    /// <para>
    /// <code>
    ///  "subtotal_set": {
    ///  "shop_money": {
    ///  "amount": 10.99,
    ///  "currency_code": "CAD"
    ///  },
    ///  "presentment_money": {
    ///  "amount": 8.95,
    ///  "currency_code": "USD"
    ///  }
    ///  }
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("subtotal_set")]
    public MoneyBag? SubTotalTaxSet { get; set; }

    /// <summary>
    /// <para>The total tax of the line item in shop and presentment currencies.</para>
    /// <para>
    /// <code>
    /// "total_tax_set": {
    ///  "shop_money": {
    ///  "amount": 10.99,
    ///  "currency_code": "CAD"
    ///  },
    ///  "presentment_money": {
    ///  "amount": 8.95,
    ///  "currency_code": "USD"
    ///  }
    ///  },
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("total_tax_set")]
    public MoneyBag? TotalTaxSet { get; set; }

    /// <summary>
    /// <para>How this refund line item affects inventory levels. Valid values:</para>
    /// <para>no_restock: Refunding these items won't affect inventory. The number of fulfillable units for this line item will remain unchanged. For example, a refund payment can be issued but no items will be returned or made available for sale again.</para>
    /// <para>cancel: The items have not yet been fulfilled. The canceled quantity will be added back to the available count. The number of fulfillable units for this line item will decrease.</para>
    /// <para>return: The items were already delivered, and will be returned to the merchant. The returned quantity will be added back to the available count. The number of fulfillable units for this line item will remain unchanged.</para>
    /// <para>legacy_restock: The deprecated restock property was used for this refund. These items were made available for sale again. This value is not accepted when creating new refunds.</para>
    /// <para>
    /// <code>
    /// "restock_type": "return"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("restock_type")]
    public string? RestockType { get; set; }

    /// <summary>
    /// <para>
    /// The unique identifier of the location where the items will be restocked.
    /// Required when restock_type has the value return or cancel.
    /// </para>
    /// <para>
    /// <code>
    /// "location_id": 40642626
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("location_id")]
    public long? LocationId { get; set; }
}
