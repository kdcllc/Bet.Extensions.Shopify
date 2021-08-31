using System;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Inventory
{
    /// <summary>
    /// A location represents a geographical location where your stores, pop-up stores, headquarters, and warehouses exist.
    /// You can use the Location resource to track sales, manage inventory, and configure the tax rates to apply at checkout.
    /// <seealso cref="!:https://shopify.dev/api/admin/rest/reference/inventory/location#properties-2021-07"/>
    /// </summary>
    public class Location : BaseModel
    {
        /// <summary>
        /// Whether the location is active.
        /// </summary>
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// The name of the location.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The first line of the address.
        /// </summary>
        [JsonPropertyName("address1")]
        public string? Address1 { get; set; }

        /// <summary>
        /// The second line of the address.
        /// </summary>
        [JsonPropertyName("address2")]
        public string? Address2 { get; set; }

        /// <summary>
        /// The zip or postal code.
        /// </summary>
        [JsonPropertyName("zip")]
        public string? Zip { get; set; }

        /// <summary>
        /// The city the location is in.
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// The province the location is in.
        /// </summary>
        [JsonPropertyName("province")]
        public string? Province { get; set; }

        /// <summary>
        /// The code of the province the location is in.
        /// </summary>
        [JsonPropertyName("province_code")]
        public string? ProvinceCode { get; set; }

        /// <summary>
        /// The country the location is in.
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// The name of the country the location is in.
        /// </summary>
        [JsonPropertyName("country_name")]
        public string? CountryName { get; set; }

        /// <summary>
        /// The code of the country the location is in.
        /// </summary>
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// The phone number of the location. Can contain special chars like - and +.
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// The date and time when the location was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The date and time when the location was last updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Whether this is a fulfillment service location. If true, then the location is a fulfillment service location. If false, then the location was created by the merchant and isn't tied to a fulfillment service.
        /// </summary>
        [JsonPropertyName("legacy")]
        public bool? Legacy { get; set; }

        /// <summary>
        /// The localized name of the location's country.
        /// </summary>
        [JsonPropertyName("localized_country_name")]
        public string? LocalizedCountryName { get; set; }

        /// <summary>
        /// The localized name of the location's region. Typically a province, state, or prefecture.
        /// </summary>
        [JsonPropertyName("localized_province_name")]
        public string? LocalizedProvinceName { get; set; }
    }
}
