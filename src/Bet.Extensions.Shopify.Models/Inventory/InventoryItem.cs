namespace Bet.Extensions.Shopify.Models.Inventory;

/// <summary>
/// There is a 1:1 relationship between a product variant and an inventory item.
/// Each product variant includes the ID of its related inventory item.
/// You can use the inventory item ID to query the InventoryLevel resource to retrieve inventory information.
/// <seealso cref="!:https://shopify.dev/api/admin/rest/reference/inventory/inventoryitem#properties-2021-07"/>.
/// </summary>
public class InventoryItem : BaseModel
{
    /// <summary>
    /// The unique SKU (Stock Keeping Unit) of the inventory item.
    /// </summary>
    [JsonPropertyName("sku")]
    public string? SKU { get; set; }

    /// <summary>
    /// Whether the inventory item is tracked. If true, then inventory quantity changes are tracked by Shopify.
    /// </summary>
    [JsonPropertyName("tracked")]
    public bool? Tracked { get; set; }

    /// <summary>
    /// The unit cost of the inventory item.
    /// </summary>
    [JsonPropertyName("cost")]
    public decimal? Cost { get; set; }

    /// <summary>
    /// The two-digit code for the country where the inventory item was made.
    /// </summary>
    [JsonPropertyName("country_code_of_origin")]
    public string? CountryCodeOfOrigin { get; set; }

    /// <summary>
    /// The two-digit code for the province where the inventory item was made. Used only if the shipping provider for the inventory item is Canada Post.
    /// </summary>
    [JsonPropertyName("province_code_of_origin")]
    public string? ProvinceCodeOfOrigin { get; set; }

    /// <summary>
    /// The general Harmonized System (HS) code for the inventory item. Used if a country-specific HS code is not available.
    /// </summary>
    [JsonPropertyName("harmonized_system_code")]
    public string? HarmonizedSystemCode { get; set; }

    /// <summary>
    /// An array of country-specific Harmonized System (HS) codes for the item. Used to determine duties when shipping the inventory item to certain countries.
    /// </summary>
    [JsonPropertyName("country_harmonized_system_codes")]
    public IEnumerable<HSCode>? CountryHarmonizedSystemCodes { get; set; }

    /// <summary>
    /// Whether a customer needs to provide a shipping address when placing an order containing the inventory item.
    /// </summary>
    [JsonPropertyName("requires_shipping")]
    public bool? RequiresShipping { get; set; }

    /// <summary>
    /// The date and time when the product variant was created. The API returns this value in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// The date and time when the product variant was last modified. The API returns this value in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
}
