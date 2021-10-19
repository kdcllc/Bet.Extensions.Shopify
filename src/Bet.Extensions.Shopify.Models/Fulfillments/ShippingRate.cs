namespace Bet.Extensions.Shopify.Models.Fulfillments;

public class ShippingRate
{
    [JsonPropertyName("rate")]
    public Rate? Rate { get; set; }
}

#pragma warning disable SA1402 // File may only contain a single type
public class Rate
#pragma warning restore SA1402 // File may only contain a single type
{
    [JsonPropertyName("origin")]
    public ShippingAddress? OriginAddress { get; set; }

    [JsonPropertyName("destination")]
    public ShippingAddress? DestinationAddress { get; set; }

    [JsonPropertyName("items")]
    public IEnumerable<ShippingLineItem>? LineItems { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("locale")]
    public string? Locale { get; set; }
}
