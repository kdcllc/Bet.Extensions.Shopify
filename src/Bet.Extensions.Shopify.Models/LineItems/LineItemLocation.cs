namespace Bet.Extensions.Shopify.Models.LineItems;

public class LineItemLocation : BaseModel
{
    /// <summary>
    /// The two-letter code (ISO 3166-1 format) for the country of the item's supplier.
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// The two-letter abbreviation for the region of the item's supplier.
    /// </summary>
    [JsonPropertyName("province_code")]
    public string? ProvinceCode { get; set; }

    /// <summary>
    /// The two-letter abbreviation for the region of the item's supplier.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The name of the item's supplier.
    /// </summary>
    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    /// <summary>
    /// The suite number of the item's supplier.
    /// </summary>
    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }

    /// <summary>
    /// The suite number of the item's supplier.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// The city of the item's supplier.
    /// </summary>
    [JsonPropertyName("zip")]
    public string? Zip { get; set; }
}
