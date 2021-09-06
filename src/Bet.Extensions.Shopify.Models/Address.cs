using System.Text.Json.Serialization;

using Bet.Extensions.Shopify.Models.Customers;

namespace Bet.Extensions.Shopify.Models
{
    /// <summary>
    ///
    ///
    /// <see href="https://shopify.dev/api/admin/rest/reference/customers/customer-address#properties-2021-07"/>.
    /// <see href=""/>.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// An unique id for the address.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// <para>The mailing address.</para>
        /// <para>
        /// <code>
        /// "address1": "1 Rue des Carrieres"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("address1")]
        public string? Address1 { get; set; }

        /// <summary>
        /// <para>An additional field for the mailing address.</para>
        /// <para>
        /// <code>
        /// "address2": "Suite 1234"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("address2")]
        public string? Address2 { get; set; }

        /// <summary>
        /// <para>The city.</para>
        /// <para>
        /// <code>
        /// "city": "Montreal"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// <para>The country.</para>
        /// <para>
        /// <code>
        /// "country": "Canada"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// <para>
        /// The two-letter country code corresponding to the country.</para>
        /// <para>
        /// <code>
        /// "country_code": "CA"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("country_code")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// <para>The normalized country name.</para>
        /// <para>
        /// <code>
        /// "country_name": "Canada"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("country_name")]
        public string? CountryName { get; set; }

        /// <summary>
        /// <para>The company.</para>
        /// <para>
        /// <code>
        /// "company": "Fancy Co."
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("company")]
        public string? Company { get; set; }

        /// <summary>
        /// <para>The first name.</para>
        /// <para>
        /// <code>
        /// "first_name": "Samuel"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// <para>The last name.</para>
        /// <para>
        /// <code>
        /// "last_name": "de Champlain"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }

        /// <summary>
        /// <para>The name.</para>
        /// <para>
        /// <code>
        /// "name": "Samuel de Champlain"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The phone number.
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// The province or state name.
        /// </summary>
        [JsonPropertyName("province")]
        public string? Province { get; set; }

        /// <summary>
        /// The two-letter province or state code.
        /// </summary>
        [JsonPropertyName("province_code")]
        public string? ProvinceCode { get; set; }

        /// <summary>
        /// The ZIP or postal code.
        /// </summary>
        [JsonPropertyName("zip")]
        public string? Zip { get; set; }

        /// <summary>
        /// <para>Indicates whether this address is the default address.</para>
        /// <para>This is read only field. <see cref="CustomerAddress"/> to update the default value.</para>
        /// <para>
        /// <code>
        /// PUT /admin/api/2021-07/customers/207119551/addresses/1053317295/default.json
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("default")]
        public bool? Default { get; set; }
    }
}
