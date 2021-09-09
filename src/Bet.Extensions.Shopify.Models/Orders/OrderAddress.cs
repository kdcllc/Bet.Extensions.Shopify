using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Orders
{
    public class OrderAddress : Address
    {
        /// <summary>
        /// The latitude. Auto-populated by Shopify on the order's Billing/Shipping address.
        /// </summary>
        [JsonPropertyName("latitude")]
        public decimal? Latitude { get; set; }

        /// <summary>
        /// The longitude. Auto-populated by Shopify on the order's Billing/Shipping address.
        /// </summary>
        [JsonPropertyName("longitude")]
        public decimal? Longitude { get; set; }
    }
}
