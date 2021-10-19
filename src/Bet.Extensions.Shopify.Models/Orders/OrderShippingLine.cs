using Bet.Extensions.Shopify.Models.LineItems;

namespace Bet.Extensions.Shopify.Models.Orders;

public class OrderShippingLine : ShippingLine
{
    /// <summary>
    /// <para>The general classification of the delivery method.</para>
    /// <para>
    /// <code>
    /// "delivery_category": null
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("delivery_category")]
    public string? DeliveryCategory { get; set; }

    /// <summary>
    /// <para>A reference to the fulfillment service that is being requested for the shipping method.
    /// Present if the shipping method requires processing by a third party fulfillment service; null otherwise.</para>
    /// <para>
    /// <code>
    /// "requested_fulfillment_service_id": "third_party_fulfillment_service_id"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("requested_fulfillment_service_id")]
    public long? RequestedFulfillmentServiceId { get; set; }
}
