namespace Bet.Extensions.Shopify.Models.LineItems;

public class ShippingLine : BaseModel
{
    /// <summary>
    /// The carrier provided identifier.
    /// </summary>
    [JsonPropertyName("carrier_identifier")]
    public string? CarrierIdentifier { get; set; }

    /// <summary>
    /// A reference to the shipping method.
    /// </summary>
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// The phone number used for the shipment.
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// The price of this shipping method.
    /// </summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    /// <summary>
    /// <para>The discounted price of this shipping method.</para>
    /// <para>
    /// <code>
    /// "discounted_price": "37.54"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("discounted_price")]
    public decimal? DiscountedPrice { get; set; }

    /// <summary>
    /// An ordered list of amounts allocated by discount applications.
    /// Each discount allocation is associated to a particular discount application.
    /// </summary>
    [JsonPropertyName("discount_allocations")]
    public IEnumerable<DiscountAllocation>? DiscountAllocations { get; set; }

    /// <summary>
    /// <para>The source of the shipping method.</para>
    /// <para>
    /// <code>
    /// "source": "fedex"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("source")]
    public string? Source { get; set; }

    /// <summary>
    /// <para>The title of the shipping method.</para>
    /// <para>
    /// <code>
    ///   "title": "FedEx Priority Overnight® Saturday Delivery"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// A list of <see cref="TaxLine"/> objects, each of which details the taxes applicable to this <see cref="ShippingLine"/>.
    /// </summary>
    [JsonPropertyName("tax_lines")]
    public IEnumerable<TaxLine>? TaxLines { get; set; }

    /// <summary>
    /// The price of the shipping method in shop and presentment currencies.
    /// </summary>
    [JsonPropertyName("price_set")]
    public MoneyBag? PriceSet { get; set; }

    /// <summary>
    /// The price of the shipping method in both shop and presentment currencies after line-level discounts have been applied.
    /// </summary>
    [JsonPropertyName("discounted_price_set")]
    public MoneyBag? DiscountedPriceSet { get; set; }
}
