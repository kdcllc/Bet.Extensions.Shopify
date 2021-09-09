using System;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Fulfillments
{
    public class CarrierRate
    {
        /// <summary>
        /// <para>The name of the rate, which customers see at checkout. For example: Expedited Mail.</para>
        /// <para>
        /// <code>
        /// "service_name": "fedex-2dayground"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("service_name")]
        public string? ServiceName { get; set; }

        /// <summary>
        /// <para>A unique code associated with the rate. For example: expedited_mail.</para>
        /// <para>
        /// <code>
        /// "service_code": "2D"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("service_code")]
        public string? ServiceCode { get; set; }

        /// <summary>
        /// <para>The total price expressed in subunits.</para>
        /// <para>If the currency does not use subunits, the value must be multiplied by 100.</para>
        /// <para>For example: `"total_price": 500` for 5.00 CAD, `"total_price": 100000` for 1000 JPY.</para>
        /// <para>
        /// <code>
        /// "total_price": "3587"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("total_price")]
        public string? TotalPrice { get; set; }

        /// <summary>
        /// <para>A description of the rate, which customers see at checkout. For example: Includes tracking and insurance.</para>
        /// <para>
        /// <code>
        /// "description": "This is the fastest option by far"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// <para>The currency of the shipping rate.</para>
        /// <para>
        /// <code>
        /// "currency": "USD"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// <para>Whether the customer must provide a phone number at checkout.</para>
        /// <para>
        /// <code>
        /// "phone_required" : true
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("phone_required")]
        public bool? PhoneRequired { get; set; }

        /// <summary>
        /// <para>The earliest delivery date for the displayed rate.</para>
        /// <para>
        /// <code>
        /// "min_delivery_date": "2013-04-12 14:48:45 -0400"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("min_delivery_date")]
        public DateTimeOffset? MinDeliveryDate { get; set; }

        /// <summary>
        /// <para>The latest delivery date for the displayed rate to still be valid.</para>
        /// <para>
        /// <code>
        /// "max_delivery_date": "2013-04-12 14:48:45 -0400"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("max_delivery_date")]
        public DateTimeOffset? MaxDeliveryDate { get; set; }
    }
}
