namespace Bet.Extensions.Shopify.Models.Fulfillments;

public class ShippingLineItem
{
    /// <summary>
    /// <para>The name of the product.</para>
    /// <para>
    /// <code>
    /// "name": "IPod Nano - 8gb"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// <para>The number of products.</para>
    /// <para>
    /// <code>
    ///  "quantity": 1
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("quantity")]
    public int? Quantity { get; set; }

    /// <summary>
    /// <para>The weight of the item in grams.</para>
    /// <para>
    /// <code>
    ///  "grams": 200
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("grams")]
    public long? Grams { get; set; }

    /// <summary>
    /// <para>The name of the supplier of the item.</para>
    /// <para>
    /// <code>
    ///   "vendor": null
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("vendor")]
    public string? Vendor { get; set; }

    /// <summary>
    /// <para>
    ///     The price of the item before discounts have been applied.
    ///     Divide by 100 or multiplied by 100.
    /// </para>
    /// <para>
    /// <code>
    ///  "price": "1990"
    /// </code>
    /// </para>
    /// </summary>
    /// <remarks>Shopify returns this value as a string.</remarks>
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    /// <summary>
    /// The unique SKU (Stock Keeping Unit) of the inventory item.
    /// </summary>
    [JsonPropertyName("sku")]
    public string? SKU { get; set; }

    /// <summary>
    /// <para>States whether or not requires shipping.</para>
    /// <para>
    /// <code>
    ///  "requires_shipping": true
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("requires_shipping")]
    public bool? RequiresShipping { get; set; }

    /// <summary>
    /// <para>States whether or not the product was taxable.</para>
    /// <para>
    /// <code>
    /// "taxable": true
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("taxable")]
    public bool? Taxable { get; set; }

    /// <summary>
    /// <para>Service provider who is doing the fulfillment.</para>
    /// <para>Valid values are either "manual" or the name of the provider. eg: "amazon", "shipwire", etc.</para>
    /// <para>
    /// <code>
    /// "fulfillment_service": "manual"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("fulfillment_service")]
    public string? FulfillmentService { get; set; }

    [JsonPropertyName("properties")]
    public object? Properties { get; set; }

    /// <summary>
    /// <para>The id of the product variant.</para>
    /// <para>
    /// <code>
    /// "variant_id": 39072856
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("variant_id")]
    public long? VariantId { get; set; }

    /// <summary>
    /// <para>The id of the product.</para>
    /// <para>
    /// <code>
    /// "product_id": 39072856
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("product_id")]
    public long? ProductId { get; set; }
}
