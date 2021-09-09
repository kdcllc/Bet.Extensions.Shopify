using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Fulfillments
{
    public class Carrier : BaseModel
    {
        /// <summary>
        /// <para>Whether this carrier service is active.</para>
        /// <para>
        /// <code>
        /// "active": true
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// <para>The URL endpoint that Shopify needs to retrieve shipping rates. This must be a public URL.</para>
        /// <para>
        /// <code>
        /// "callback_url": "http://myapp.com"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("callback_url")]
        public string? CallbackUrl { get; set; }

        /// <summary>
        /// <para>Distinguishes between API or legacy carrier services.</para>
        /// <para>
        /// <code>
        /// "carrier_service_type": "api"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("carrier_service_type")]
        public string? CarrierServiceType { get; set; }

        /// <summary>
        /// <para>The name of the shipping service as seen by merchants and their customers.</para>
        /// <para>
        /// <code>
        /// "name": "My Carrier Service"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// <para>Whether merchants are able to send dummy data to your service through the Shopify admin to see shipping rate examples.</para>
        /// <para>
        /// <code>
        /// "service_discovery": true
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("service_discovery")]
        public bool? ServiceDiscovery { get; set; }

        /// <summary>
        /// <para>The format of the data returned by the URL endpoint. Valid values: json and xml. Default value: json.</para>
        /// <para>
        /// <code>
        /// "format": "json"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("format")]
        public string? Format { get; set; }
    }
}
