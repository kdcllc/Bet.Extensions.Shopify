namespace Bet.Extensions.Shopify.Models.Inventory;

/// <summary>
/// An array of country-specific Harmonized System (HS) codes for the item.
/// Used to determine duties when shipping the inventory item to certain countries.
/// <seealso cref="!:https://shopify.dev/api/admin/rest/reference/inventory/inventoryitem#properties-2021-07"/>
/// </summary>
public class HSCode : BaseModel
{
    /// <summary>
    /// The two-digit code for the country where the inventory item was made.
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// The general Harmonized System (HS) code for the inventory item. Used if a country-specific HS code is not available.
    /// </summary>
    [JsonPropertyName("harmonized_system_code")]
    public string? HarmonizedSystemCode { get; set; }
}
