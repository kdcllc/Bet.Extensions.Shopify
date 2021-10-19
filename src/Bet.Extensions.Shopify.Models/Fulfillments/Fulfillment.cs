namespace Bet.Extensions.Shopify.Models.Fulfillments;

/// <summary>
/// <para>The Shopify API lets you do the following with the Fulfillment resource. More detailed versions of these general actions may be available:</para>
/// <para>
/// GET /admin/api/2021-07/orders/{order_id}/fulfillments.json
/// Retrieves fulfillments associated with an order.
/// </para>
/// <para>
/// GET /admin/api/2021-07/fulfillment_orders/{fulfillment_order_id}/fulfillments.json
/// Retrieves fulfillments associated with a fulfillment order.
/// </para>
/// <para>
/// GET /admin/api/2021-07/orders/{order_id}/fulfillments/count.json
/// Retrieves a count of fulfillments associated with a specific order.
/// </para>
/// <para>
/// GET /admin/api/2021-07/orders/{order_id}/fulfillments/{fulfillment_id}.json
/// Receive a single Fulfillment.
/// </para>
/// <para>
/// POST /admin/api/2021-07/orders/{order_id}/fulfillments.json
/// Create a new Fulfillment.
/// </para>
/// <para>
/// POST /admin/api/2021-07/fulfillments.json
/// Creates a fulfillment for one or many fulfillment orders.
/// </para>
/// <para>
/// PUT /admin/api/2021-07/orders/{order_id}/fulfillments/{fulfillment_id}.json
/// Modify an existing Fulfillment.
/// </para>
/// <para>
/// POST /admin/api/2021-07/fulfillments/{fulfillment_id}/update_tracking.json
/// Updates the tracking information for a fulfillment.
/// </para>
/// <para>
/// POST /admin/api/2021-07/orders/{order_id}/fulfillments/{fulfillment_id}/complete.json
/// Complete a fulfillment.
/// </para>
/// <para>
/// POST /admin/api/2021-07/orders/{order_id}/fulfillments/{fulfillment_id}/open.json
/// Transition a fulfillment from pending to open.
/// </para>
/// <para>
/// POST /admin/api/2021-07/orders/{order_id}/fulfillments/{fulfillment_id}/cancel.json
/// Cancel a fulfillment for a specific order ID.
/// </para>
/// <para>
/// POST /admin/api/2021-07/fulfillments/{fulfillment_id}/cancel.json
/// Cancels a fulfillment.
/// </para>
/// <para><see href="https://shopify.dev/api/admin/rest/reference/shipping-and-fulfillment/fulfillment#properties-2021-07"/>.</para>
/// </summary>
public class Fulfillment : BaseModel
{
    /// <summary>
    /// <para>The date and time when the fulfillment was created. The API returns this value in ISO 8601 format.</para>
    /// <para>
    /// <code>
    /// "created_at": "2012-03-13T16:09:54-04:00"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// <para>The unique identifier of the location that the fulfillment should be processed for.</para>
    /// <para>To find the ID of the location, use the Location resource.</para>
    /// <para>
    /// <code>
    ///  "location_id": 40642626
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("location_id")]
    public long? LocationId { get; set; }

    /// <summary>
    /// <para>The uniquely identifying fulfillment name, consisting of two parts separated by a ..</para>
    /// <para>The first part represents the order name and the second part represents the fulfillment number.</para>
    /// <para>The fulfillment number automatically increments depending on how many fulfillments are in an order (e.g. #1001.1, #1001.2).</para>
    /// <para>
    /// <code>
    ///  "name": "#1001.1"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// <para>The unique numeric identifier for the order.</para>
    /// <para>
    /// <code>
    /// "order_id": 450789469
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("order_id")]
    public long? OrderId { get; set; }

    /// <summary>
    /// <para>A textfield with information about the receipt.</para>
    /// <para>
    /// <code>
    ///  "receipt": {
    ///  "testcase": true,
    ///  "authorization": "123456"
    ///  }
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("receipt")]
    public Receipt? Receipt { get; set; }

    /// <summary>
    /// <para>The type of service used.</para>
    /// <para>
    /// <code>
    /// "service": "manual"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("service")]
    public string? Service { get; set; }

    /// <summary>
    /// <para>The current shipment status of the fulfillment. Valid values:</para>
    /// <para>label_printed: A label for the shipment was purchased and printed.</para>
    /// <para>label_purchased: A label for the shipment was purchased, but not printed.</para>
    /// <para>attempted_delivery: Delivery of the shipment was attempted, but unable to be completed.</para>
    /// <para>ready_for_pickup: The shipment is ready for pickup at a shipping depot.</para>
    /// <para>confirmed: The carrier is aware of the shipment, but hasn't received it yet.</para>
    /// <para>in_transit: The shipment is being transported between shipping facilities on the way to its destination.</para>
    /// <para>out_for_delivery: The shipment is being delivered to its final destination.</para>
    /// <para>delivered: The shipment was successfully delivered.</para>
    /// <para>failure: Something went wrong when pulling tracking information for the shipment, such as the tracking number was invalid or the shipment was canceled.</para>
    /// <para>
    /// <code>
    /// "shipment_status": "confirmed"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("shipment_status")]
    public string? ShipmentStatus { get; set; }

    /// <summary>
    /// <para>The status of the fulfillment. Valid values:</para>
    /// <para>pending: The fulfillment is pending.</para>
    /// <para>open: The fulfillment has been acknowledged by the service and is in processing.</para>
    /// <para>success: The fulfillment was successful.</para>
    /// <para>cancelled: The fulfillment was cancelled.</para>
    /// <para>error: There was an error with the fulfillment request.</para>
    /// <para>failure: The fulfillment request failed.</para>
    /// <para>
    /// <code>
    /// "status": "failure"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// <para>The name of the tracking company.</para>
    /// <para>DHL Express.</para>
    /// <para>FedEx.</para>
    /// <para>UPS.</para>
    /// <para>USPS.</para>
    /// <para>
    /// <code>
    /// "tracking_company": "China Post"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("tracking_company")]
    public string? TrackingCompany { get; set; }

    /// <summary>
    /// <para>A list of tracking number, provided by the shipping company.</para>
    /// <para>
    /// <code>
    /// "tracking_numbers": "1234567"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("tracking_number")]
    public string? TrackingNumber { get; set; }

    /// <summary>
    /// <para>A list of tracking numbers, provided by the shipping company. May be null.</para>
    /// <para>
    /// <code>
    ///  "tracking_numbers": ["1234356"]
    ///  </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("tracking_numbers")]
    public IEnumerable<string>? TrackingNumbers { get; set; }

    /// <summary>
    /// <para>The tracking url, provided by the shipping company. May be null.</para>
    /// <para>
    /// <code>
    /// "tracking_url": "http://track-chinapost.com/startairmail.php?code=112345Z2345"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("tracking_url")]
    public string? TrackingUrl { get; set; }

    /// <summary>
    /// <para>The URLs of tracking pages for the fulfillment. May be null.</para>
    /// <para>
    /// <code>
    /// "tracking_urls": ["http://track-chinapost.com/startairmail.php?code=112345Z2345"]
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("tracking_urls")]
    public IEnumerable<string>? TrackingUrls { get; set; }

    /// <summary>
    /// <para>The date and time (ISO 8601 format) when the fulfillment was last modified.</para>
    /// <para>
    /// <code>
    ///  "updated_at": "2012-05-01T14:22:25-04:00"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// <para>A historical record of each item in the fulfillment.</para>
    /// <para>
    /// <code>
    /// "line_items": []
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("line_items")]
    public IEnumerable<ShippingLineItem>? LineItems { get; set; }

    /// <summary>
    /// <para>Whether the customer should be notified.</para>
    /// <para>If set to true, then an email will be sent when the fulfillment is created or updated.</para>
    /// <para>For orders that were initially created using the API, the default value is false.</para>
    /// <para>For all other orders, the default value is true.</para>
    /// <para>
    /// <code>
    /// "notify_customer": true
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("notify_customer")]
    public bool? NotifyCustomer { get; set; }

    /// <summary>
    /// <para>The name of the inventory management service.</para>
    /// <para>
    /// <code>
    /// "variant_inventory_management": "shopify"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("variant_inventory_management")]
    public string? VariantInventoryManagement { get; set; }
}
