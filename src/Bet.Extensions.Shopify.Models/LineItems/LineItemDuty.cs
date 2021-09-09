using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.LineItems
{
    /// <summary>
    /// <code>
    ///   "duties": [
    ///   {
    ///   "id": "2",
    ///   "harmonized_system_code": "520300",
    ///   "country_code_of_origin": "CA",
    ///   "shop_money": {
    ///   "amount": "164.86",
    ///   "currency_code": "CAD"
    ///   },
    ///   "presentment_money": {
    ///   "amount": "105.31",
    ///   "currency_code": "EUR"
    ///   },
    ///   "tax_lines": [
    ///   {
    ///   "title": "VAT",
    ///   "price": "16.486",
    ///   "rate": 0.1,
    ///   "price_set": {
    ///   "shop_money": {
    ///   "amount": "16.486",
    ///   "currency_code": "CAD"
    ///   },
    ///   "presentment_money": {
    ///   "amount": "10.531",
    ///   "currency_code": "EUR"
    ///   }
    ///   }
    ///   }
    ///   ],
    ///   "admin_graphql_api_id": "gid://shopify/Duty/2"
    ///   }
    ///   ]
    /// </code>
    /// </summary>
    public class LineItemDuty : BaseModel
    {
        [JsonPropertyName("harmonized_system_code")]
        public string? HarmonizedSystemCode { get; set; }

        [JsonPropertyName("country_code_of_origin")]
        public string? CountryCodeOfOrigin { get; set; }

        [JsonPropertyName("shop_money")]
        public Money? ShopMoney { get; set; }

        [JsonPropertyName("presentment_money")]
        public Money? PresentmentMoney { get; set; }

        [JsonPropertyName("tax_lines")]
        public IEnumerable<TaxLine>? TaxLines { get; set; }
    }
}
