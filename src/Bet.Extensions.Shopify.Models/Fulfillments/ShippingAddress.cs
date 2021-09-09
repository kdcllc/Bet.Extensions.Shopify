using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Fulfillments
{
    public class ShippingAddress
    {
        /// <summary>
        /// <para>Country Code.</para>
        /// <para>
        /// <code>
        /// "country": "US"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// <para>Post Code or Zip Code.</para>
        /// <para>
        /// <code>
        /// "postal_code": "28112"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("postal_code")]
        public string? PostalCode { get; set; }

        /// <summary>
        /// <para>State or Province.</para>
        /// <para>
        /// <code>
        /// "province": "NC"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("province")]
        public string? Province { get; set; }

        /// <summary>
        /// <para>City.</para>
        /// <para>
        /// <code>
        /// "city": "Charlotte"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("city")]
        public string? City { get; set; }

        /// <summary>
        /// <para>Customer's full name.</para>
        /// <para>
        /// <code>
        ///  "name": "First and Last Name"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// <para>Street Address Line 1.</para>
        /// <para>
        /// <code>
        /// "address1": "Lexington Avenue"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("address1")]
        public string? Address1 { get; set; }

        /// <summary>
        /// Street Address Line 2.
        /// </summary>
        [JsonPropertyName("address2")]
        public string? Address2 { get; set; }

        /// <summary>
        /// Street Address Line 3.
        /// </summary>
        [JsonPropertyName("address3")]
        public string? Address3 { get; set; }

        /// <summary>
        /// Phone number if required.
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// Fax number.
        /// </summary>
        [JsonPropertyName("fax")]
        public string? Fax { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("address_type")]
        public string? AddressType { get; set; }

        /// <summary>
        /// Company Name.
        /// </summary>
        [JsonPropertyName("company_name")]
        public string? CompanyName { get; set; }
    }
}
