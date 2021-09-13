using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

using Bet.Extensions.Shopify.Models.Customers;
using Bet.Extensions.Shopify.Models.Fulfillments;
using Bet.Extensions.Shopify.Models.LineItems;

namespace Bet.Extensions.Shopify.Models.Orders
{
    /// <summary>
    /// <para>The Shopify API lets you do the following with the Order resource.</para>
    /// <para>More detailed versions of these general actions may be available:</para>
    /// <para>
    /// GET /admin/api/2021-07/orders.json?status=any
    /// Retrieve a list of orders.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/orders/{order_id}.json
    /// Retrieve a specific order.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/orders/count.json
    /// Retrieve an order count.
    /// </para>
    /// <para>
    /// POST /admin/api/2021-07/orders/{order_id}/close.json
    /// Close an order.
    /// </para>
    /// <para>
    /// POST /admin/api/2021-07/orders/{order_id}/open.json
    /// Re-open a closed order.
    /// </para>
    /// <para>
    /// POST /admin/api/2021-07/orders/{order_id}/cancel.json
    /// Cancel an order.
    /// </para>
    /// <para>
    /// POST /admin/api/2021-07/orders.json
    /// Create an order.
    /// </para>
    /// <para>
    /// PUT /admin/api/2021-07/orders/{order_id}.json
    /// Update an order.
    /// </para>
    /// <para>
    /// DELETE /admin/api/2021-07/orders/{order_id}.json
    /// Delete an order.
    /// </para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/orders/order#properties-2021-07"/>.</para>
    /// </summary>
    public class Order : BaseModel
    {
        /// <summary>
        /// <para>The ID of the app that created the order.</para>
        /// <para>
        /// <code>
        /// "app_id": 1966818
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("app_id")]
        public long? AppId { get; set; }

        /// <summary>
        /// <para>The mailing address associated with the payment method.</para>
        /// <para>This address is an optional field that won't be available on orders that do not require a payment method.</para>
        /// <para>
        /// <code>
        /// "billing_address": {
        /// "address1": "2259 Park Ct",
        /// "address2": "Apartment 5",
        /// "city": "Drayton Valley",
        /// "company": null,
        /// "country": "Canada",
        /// "first_name": "Christopher",
        /// "last_name": "Gorski",
        /// "phone": "(555)555-5555",
        /// "province": "Alberta",
        /// "zip": "T0E 0M0",
        /// "name": "Christopher Gorski",
        /// "province_code": "AB",
        /// "country_code": "CA",
        /// "latitude": "45.41634",
        /// "longitude": "-75.6868"
        /// }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("billing_address")]
        public OrderAddress? BillingAddress { get; set; }

        /// <summary>
        /// <para>
        ///     The IP address of the browser used by the customer when they placed the order. Both IPv4 and IPv6 are supported.</para>
        /// <para>
        /// <code>
        /// "browser_ip": "216.191.105.146"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("browser_ip")]
        public string? BrowserIp { get; set; }

        /// <summary>
        /// <para>
        ///     Whether the customer consented to receive email updates from the shop.</para>
        /// <para>
        /// <code>
        /// "buyer_accepts_marketing": false
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("buyer_accepts_marketing")]
        public bool? BuyerAcceptsMarketing { get; set; }

        /// <summary>
        /// <para>The reason why the order was canceled. Valid values:</para>
        /// <para>customer: The customer canceled the order.</para>
        /// <para>fraud: The order was fraudulent.</para>
        /// <para>inventory: Items in the order were not in inventory.</para>
        /// <para>declined: The payment was declined.</para>
        /// <para>other: A reason not in this list.</para>
        /// </summary>
        [JsonPropertyName("cancel_reason")]
        public string? CancelReason { get; set; }

        /// <summary>
        /// <para>The date and time when the order was canceled.</para>
        /// <para>Returns null if the order isn't canceled.</para>
        /// <para>
        /// <code>
        /// "cancelled_at": null
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("cancelled_at")]
        public DateTimeOffset? CancelledAt { get; set; }

        /// <summary>
        /// <para>Information about the browser that the customer used when they placed their order.</para>
        /// <para>
        /// <code>
        ///  "client_details": {
        ///  "accept_language": "en-US,en;q=0.9",
        ///  "browser_height": 1320,
        ///  "browser_ip": "216.191.105.146",
        ///  "browser_width": 1280,
        ///  "session_hash": "9ad4d1f4e6a8977b9dd98eed1e477643",
        ///  "user_agent": "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_13_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36"
        ///  }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("client_details")]
        public ClientDetails? ClientDetails { get; set; }

        /// <summary>
        /// <para>The date and time (ISO 8601 format) when the order was closed. Returns null if the order isn't closed.</para>
        /// <para>
        /// <code>
        /// "closed_at": "2008-01-10T11:00:00-05:00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("closed_at")]
        public DateTimeOffset? ClosedAt { get; set; }

        /// <summary>
        /// <para>The autogenerated date and time (ISO 8601 format) when the order was created in Shopify. The value for this property cannot be changed.</para>
        /// <para>
        /// <code>
        ///   "created_at": "2008-01-10T11:00:00-05:00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// <para>The three-letter code (ISO 4217 format) for the shop currency.</para>
        /// <para>
        /// <code>
        ///  "currency": "USD"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// <para>The current total discounts on the order in the shop currency. The value of this field reflects order edits, returns, and refunds.</para>
        /// <para>
        /// <code>
        /// "current_total_discounts": "10.00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("current_total_discounts")]
        public decimal? CurrentTotalDiscounts { get; set; }

        /// <summary>
        /// <para>The current total discounts on the order in shop and presentment currencies.</para>
        /// <para>The amount values associated with this field reflect order edits, returns, and refunds.</para>
        /// <para>
        /// <code>
        ///  "current_total_discounts_set": {
        ///  "shop_money": {
        ///  "amount": "10.00",
        ///  "currency_code": "CAD"
        ///  },
        ///  "presentment_money": {
        ///  "amount": "5.00",
        ///  "currency_code": "EUR"
        ///  }
        ///  }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("current_total_discounts_set")]
        public MoneyBag? CurrentTotalDiscountsSet { get; set; }

        /// <summary>
        /// <para>The current total duties charged on the order in shop and presentment currencies.</para>
        /// <para>The amount values associated with this field reflect order edits, returns, and refunds.</para>
        /// <para>
        /// <code>
        ///  "current_total_duties_set": {
        ///  "shop_money": {
        ///  "amount": "164.86",
        ///  "currency_code": "CAD"
        ///  },
        ///  "presentment_money": {
        ///  "amount": "105.31",
        ///  "currency_code": "EUR"
        ///  }
        ///  }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("current_total_duties_set")]
        public MoneyBag? CurrentTotalDutiesSet { get; set; }

        /// <summary>
        /// <para>The current total price of the order in the shop currency.</para>
        /// <para>The value of this field reflects order edits, returns, and refunds.</para>
        /// <para>
        /// <code>
        /// "current_total_price": "10.00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("current_total_price")]
        public decimal? CurrentTotalPrice { get; set; }

        /// <summary>
        /// <para>The current total price of the order in shop and presentment currencies.</para>
        /// <para>The amount values associated with this field reflect order edits, returns, and refunds.</para>
        /// <para>
        /// <code>
        ///  "current_total_price_set": {
        ///  "shop_money": {
        ///  "amount": "30.00",
        ///  "currency_code": "CAD"
        ///  },
        ///  "presentment_money": {
        ///  "amount": "20.00",
        ///  "currency_code": "EUR"
        ///  }
        ///  }        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("current_total_price_set")]
        public MoneyBag? CurrentTotalPriceSet { get; set; }

        /// <summary>
        /// <para>The current subtotal price of the order in the shop currency.</para>
        /// <para>The value of this field reflects order edits, returns, and refunds.</para>
        /// <para>
        /// <code>
        /// "current_subtotal_price": "10.00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("current_subtotal_price")]
        public decimal? CurrentSubtotalPrice { get; set; }

        /// <summary>
        /// <para>The current subtotal price of the order in shop and presentment currencies.</para>
        /// <para>The amount values associated with this field reflect order edits, returns, and refunds.</para>
        /// <para>
        /// <code>
        ///  "current_subtotal_price_set": {
        ///  "shop_money": {
        ///  "amount": "30.00",
        ///  "currency_code": "CAD"
        ///  },
        ///  "presentment_money": {
        ///  "amount": "20.00",
        ///  "currency_code": "EUR"
        ///  }
        ///  }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("current_subtotal_price_set")]
        public MoneyBag? CurrentSubtotalPriceSet { get; set; }

        /// <summary>
        /// <para>The current total taxes charged on the order in the shop currency.</para>
        /// <para>The value of this field reflects order edits, returns, or refunds.</para>
        /// <para>
        /// <code>
        /// "current_total_tax": "10.00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("current_total_tax")]
        public decimal? CurrentTotalTax { get; set; }

        /// <summary>
        /// <para>The current total taxes charged on the order in shop and presentment currencies.</para>
        /// <para>The amount values associated with this field reflect order edits, returns, and refunds.</para>
        /// <para>
        /// <code>
        ///  "current_total_tax_set": {
        ///  "shop_money": {
        ///  "amount": "30.00",
        ///  "currency_code": "CAD"
        ///  },
        ///  "presentment_money": {
        ///  "amount": "20.00",
        ///  "currency_code": "EUR"
        ///  }
        ///  }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("current_total_tax_set")]
        public MoneyBag? CurrentTotalTaxSet { get; set; }

        /// <summary>
        /// <para>Information about the customer.</para>
        /// <para>The order might not have a customer and apps should not depend on the existence of a customer object.</para>
        /// <para>This value might be null if the order was created through Shopify POS.</para>
        /// <para>For more information about the customer object, see the Customer resource.</para>
        /// <para>
        /// <code>
        /// "customer": {
        /// "id": 207119551,
        /// "email": "bob.norman@hostmail.com",
        /// "accepts_marketing": false,
        /// "created_at": "2012-03-13T16:09:55-04:00",
        /// "updated_at": "2012-03-13T16:09:55-04:00",
        /// "first_name": "Bob",
        /// "last_name": "Norman",
        /// "orders_count": "1",
        /// "state": "disabled",
        /// "total_spent": "0.00",
        /// "last_order_id": 450789469,
        /// "note": null,
        /// "verified_email": true,
        /// "multipass_identifier": null,
        /// "tax_exempt": false,
        /// "tax_exemptions": {},
        /// "phone": "+13125551212",
        /// "tags": "loyal",
        /// "last_order_name": "#1001",
        /// "currency": "USD",
        /// "addresses": {},
        /// "admin_graphql_api_id": "gid://shopify/Customer/207119551",
        /// "default_address": {}
        /// }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("customer")]
        public Customer? Customer { get; set; }

        /// <summary>
        /// <para>The two or three-letter language code, optionally followed by a region modifier.</para>
        /// <para>
        /// <code>
        ///  "customer_locale": "en-CA"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("customer_locale")]
        public string? CustomerLocale { get; set; }

        /// <summary>
        /// <para>An ordered list of stacked discount applications.</para>
        /// <para>
        /// <code>
        /// "discount_applications": [
        /// {
        /// "type": "manual",
        /// "title": "custom discount",
        /// "description": "customer deserved it",
        /// "value": "2.0",
        /// "value_type": "fixed_amount",
        /// "allocation_method": "across",
        /// "target_selection": "explicit",
        /// "target_type": "line_item"
        /// },
        /// {
        /// "type": "script",
        /// "description": "my scripted discount",
        /// "value": "5.0",
        /// "value_type": "fixed_amount",
        /// "allocation_method": "across",
        /// "target_selection": "explicit",
        /// "target_type": "shipping_line"
        /// },
        /// {
        /// "type": "discount_code",
        /// "code": "SUMMERSALE",
        /// "value": "10.0",
        /// "value_type": "fixed_amount",
        /// "allocation_method": "across",
        /// "target_selection": "all",
        /// "target_type": "line_item"
        /// }
        /// ]        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("discount_applications")]
        public IEnumerable<DiscountApplication>? DiscountApplications { get; set; }

        /// <summary>
        /// <para>A list of discounts applied to the order.</para>
        /// <para>
        /// <code>
        ///   "discount_codes": [
        ///   {
        ///   "code": "SPRING30",
        ///   "amount": "30.00",
        ///   "type": "fixed_amount"
        ///   }
        ///   ]        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("discount_codes")]
        public IEnumerable<DiscountCode>? DiscountCodes { get; set; }

        /// <summary>
        /// <para>The order's email address.</para>
        /// <para>
        /// <code>
        /// "email": "bob.norman@hostmail.com"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// <para>Whether taxes on the order are estimated.</para>
        /// <para>Many factors can change between the time a customer places an order and the time the order is shipped, which could affect the calculation of taxes.</para>
        /// <para>This property returns false when taxes on the order are finalized and aren't subject to any changes.</para>
        /// <para>
        /// <code>
        ///     "estimated_taxes": false
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("estimated_taxes")]
        public bool? EstimatedTaxes { get; set; }

        /// <summary>
        /// <para>The status of payments associated with the order. Can only be set when the order is created. Valid values:</para>
        /// <para>pending: The payments are pending. Payment might fail in this state. Check again to confirm whether the payments have been paid successfully.</para>
        /// <para>authorized: The payments have been authorized.</para>
        /// <para>partially_paid: The order has been partially paid.</para>
        /// <para>paid: The payments have been paid.</para>
        /// <para>partially_refunded: The payments have been partially refunded.</para>
        /// <para>refunded: The payments have been refunded.</para>
        /// <para>voided: The payments have been voided.</para>
        /// <para>
        /// <code>
        ///  "financial_status": "authorized"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("financial_status")]
        public string? FinancialStatus { get; set; }

        /// <summary>
        /// <para>An array of fulfillments associated with the order.</para>
        /// <para>
        /// <code>
        ///  "fulfillments": []
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("fulfillments")]
        public IEnumerable<Fulfillment>? Fulfillments { get; set; }

        /// <summary>
        /// <para>The order's status in terms of fulfilled line items. Valid values:</para>
        /// <para>fulfilled: Every line item in the order has been fulfilled.</para>
        /// <para>null: None of the line items in the order have been fulfilled.</para>
        /// <para>partial: At least one line item in the order has been fulfilled.</para>
        /// <para>restocked: Every line item in the order has been restocked and the order canceled.</para>
        /// <para>
        /// <code>
        ///  "fulfillment_status": "partial"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("fulfillment_status")]
        public string? FulfillmentStatus { get; set; }

        /// <summary>
        /// <para>The payment gateway used.</para>
        /// <para>
        /// <code>
        ///  "gateway": "shopify_payments"
        /// </code>
        /// </para>
        /// </summary>
        [Obsolete("Use Transaction Api")]
        [JsonPropertyName("gateway")]
        public string? Gateway { get; set; }

        /// <summary>
        /// <para>The URL for the page where the buyer landed when they entered the shop.</para>
        /// <para>
        /// <code>
        ///  "landing_site": "http://www.example.com?source=abc"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("landing_site")]
        public string? LandingSite { get; set; }

        /// <summary>
        /// <para>A list of line item objects, each containing information about an item in the order.</para>
        /// <para>
        /// <code>
        ///  "line_items": []
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("line_items")]
        public IEnumerable<LineItem>? LineItems { get; set; }

        /// <summary>
        /// <para>
        /// The ID of the physical location where the order was processed.</para>
        /// <para>If you need to reference the location against an order, then use the FulfillmentOrder resource.</para>
        /// <para>
        /// <code>
        /// "location_id": 49202758
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("location_id")]
        public long? LocationId { get; set; }

        /// <summary>
        /// <para>The order name, generated by combining the order_number property with the order prefix and suffix that are set in the merchant's general settings.</para>
        /// <para>This is different from the id property, which is the ID of the order used by the API.</para>
        /// <para>This field can also be set by the API to be any string value.</para>
        /// <para>
        /// <code>
        /// "name": "#1001"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// <para>An optional note that a shop owner can attach to the order.</para>
        /// <para>
        /// <code>
        /// "note": "Customer changed their mind."
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("note")]
        public string? Note { get; set; }

        /// <summary>
        /// <para>Extra information that is added to the order.</para>
        /// <para>Appears in the Additional details section of an order details page. Each array entry must contain a hash with name and value keys.</para>
        /// <para>
        /// <code>
        /// "note_attributes": []
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("note_attributes")]
        public IEnumerable<Property>? NoteAttributes { get; set; }

        /// <summary>
        /// <para>The order 's position in the shop's count of orders starting at 1001.</para>
        /// <para>Order numbers are sequential and start at 1001.</para>
        /// <para>
        /// <code>
        /// "order_number": 1001
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("number")]
        public int? Number { get; set; }

        /// <summary>
        /// <para>The order 's position in the shop's count of orders starting at 1001. Order numbers are sequential and start at 1001.</para>
        /// <para>
        /// <code>
        /// "order_number": 1001
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("order_number")]
        public int? OrderNumber { get; set; }

        /// <summary>
        /// <para>
        /// The original total duties charged on the order in shop and presentment currencies.</para>
        /// <para>
        /// <code>
        /// "original_total_duties_set": {
        ///   "shop_money": {
        ///     "amount": "164.86",
        ///     "currency_code": "CAD"
        ///   },
        ///   "presentment_money": {
        ///     "amount": "105.31",
        ///     "currency_code": "EUR"
        ///   }
        /// }
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("original_total_duties_set")]
        public MoneyBag? OriginalTotalDutiesSet { get; set; }

        /// <summary>
        /// <para>
        /// An object containing information about the payment. It has the following properties:
        /// avs_result_code: The response code from the address verification system (AVS). The code is a single letter. See this chart for the codes and their definitions.
        /// </para>
        /// <para>credit_card_bin: The issuer identification number (IIN), formerly known as the bank identification number (BIN), of the.</para>
        /// <para>customer's credit card. This is made up of the first few digits of the credit card number.</para>
        /// <para>credit_card_company: The name of the company who issued the customer's credit card.</para>
        /// <para>credit_card_number: The customer's credit card number, with most of the leading digits redacted.</para>
        /// <para>cvv_result_code: The response code from the credit card company indicating whether the customer entered the card security code (card verification value) correctly. The code is a single letter or empty string. See this chart for the codes and their  definitions.</para>
        /// <para>
        /// <code>
        /// "payment_details": {
        /// "avs_result_code": "Y",
        /// "credit_card_bin": "453600",
        /// "cvv_result_code": "M",
        /// "credit_card_number": "•••• •••• •••• 4242",
        /// "credit_card_company": "Visa"
        /// }
        /// </code>
        /// </para>
        /// </summary>
        [Obsolete($"Use {nameof(Transaction)} ")]
        [JsonPropertyName("payment_details")]
        public PaymentDetails? PaymentDetails { get; set; }

        /// <summary>
        /// <para>The list of payment gateways used for the order.</para>
        /// <para>
        /// <code>
        /// "payment_gateway_names": [
        /// "authorize_net",
        /// "Cash on Delivery (COD)"
        /// ]
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("payment_gateway_names")]
        public IEnumerable<string>? PaymentGatewayNames { get; set; }

        /// <summary>
        /// <para>The customer's phone number for receiving SMS notifications.</para>
        /// <para>
        /// <code>
        ///  "phone": "+557734881234"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("phone")]
        public string? Phone { get; set; }

        /// <summary>
        /// <para>The presentment currency that was used to display prices to the customer.</para>
        /// <para>
        /// <code>
        /// "presentment_currency": "CAD"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("presentment_currency")]
        public string? PresentmentCurrency { get; set; }

        /// <summary>
        /// <para>The date and time (ISO 8601 format) when an order was processed. This value is the date that appears on your orders and that's used in the analytic reports. If you're importing orders from an app or another platform, then you can set processed_at to a date and time in the past to match when the original order was created.</para>
        /// <para>
        /// <code>
        /// "processed_at": "2008-01-10T11:00:00-05:00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("processed_at")]
        public DateTimeOffset? ProcessedAt { get; set; }

        /// <summary>
        /// <para>How the payment was processed. It has the following valid values:</para>
        /// <para>checkout: The order was processed using the Shopify checkout.</para>
        /// <para>direct: The order was processed using a direct payment provider.</para>
        /// <para>manual: The order was processed using a manual payment method.</para>
        /// <para>offsite: The order was processed by an external payment provider to the Shopify checkout.</para>
        /// <para>express: The order was processed using PayPal Express Checkout.</para>
        /// <para>free: The order was processed as a free order using a discount code.</para>
        /// <para>
        /// <code>
        /// "processing_method": "direct"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("processing_method")]
        public string? ProcessingMethod { get; set; }

        /// <summary>
        /// <para>The website where the customer clicked a link to the shop.</para>
        /// <para>
        /// <code>
        /// "referring_site": "http://www.anexample.com"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("referring_site")]
        public string? ReferringSite { get; set; }

        /// <summary>
        /// <para>A list of refunds applied to the order. For more information, see the Refund API.</para>
        /// <para>
        /// <code>
        /// "refunds": []
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("refunds")]
        public IEnumerable<Refund>? Refunds { get; set; }

        /// <summary>
        /// <para>The mailing address to where the order will be shipped.</para>
        /// <para>
        /// <code>
        ///  "shipping_address": {
        ///  "address1": "123 Amoebobacterieae St",
        ///  "address2": "",
        ///  "city": "Ottawa",
        ///  "company": null,
        ///  "country": "Canada",
        ///  "first_name": "Bob",
        ///  "last_name": "Bobsen",
        ///  "latitude": "45.41634",
        ///  "longitude": "-75.6868",
        ///  "phone": "555-625-1199",
        ///  "province": "Ontario",
        ///  "zip": "K2P0V6",
        ///  "name": "Bob Bobsen",
        ///  "country_code": "CA",
        ///  "province_code": "ON"
        ///  }        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("shipping_address")]
        public OrderAddress? ShippingAddress { get; set; }

        /// <summary>
        /// An array of <see cref="OrderShippingLine"/> objects, each of which details the shipping methods used.
        /// </summary>
        [JsonPropertyName("shipping_lines")]
        public IEnumerable<OrderShippingLine>? ShippingLines { get; set; }

        /// <summary>
        /// Where the order originated. May only be set during creation, and is not writeable thereafter.
        /// Orders created via the API may be assigned any string of your choice except for "web", "pos", "iphone", and "android".
        /// Default is "api".
        /// </summary>
        [JsonPropertyName("source_name")]
        public string? SourceName { get; set; }

        /// <summary>
        /// The price of the order in the shop currency after discounts but before shipping, duties, taxes, and tips.
        /// </summary>
        [JsonPropertyName("subtotal_price")]
        public decimal? SubTotalPrice { get; set; }

        /// <summary>
        /// The subtotal of the order in shop and presentment currencies after discounts but before shipping, duties, taxes, and tips.
        /// </summary>
        [JsonPropertyName("subtotal_price_set")]
        public MoneyBag? SubTotalPriceSet { get; set; }

        /// <summary>
        /// Tags are additional short descriptors, commonly used for filtering and searching, formatted as a string of comma-separated values.
        /// </summary>
        [JsonPropertyName("tags")]
        public string? Tags { get; set; }

        /// <summary>
        /// An array of <see cref="TaxLine"/> objects, each of which details the total taxes applicable to the order.
        /// </summary>
        [JsonPropertyName("tax_lines")]
        public IEnumerable<TaxLine>? TaxLines { get; set; }

        /// <summary>
        /// States whether or not taxes are included in the order subtotal.
        /// </summary>
        [JsonPropertyName("taxes_included")]
        public bool? TaxesIncluded { get; set; }

        /// <summary>
        /// States whether this is a test order.
        /// </summary>
        [JsonPropertyName("test")]
        public bool? Test { get; set; }

        /// <summary>
        /// Unique identifier for a particular order.
        /// </summary>
        [JsonPropertyName("token")]
        public string? Token { get; set; }

        /// <summary>
        /// The total amount of the discounts applied to the price of the order.
        /// </summary>
        [JsonPropertyName("total_discounts")]
        public decimal? TotalDiscounts { get; set; }

        /// <summary>
        /// The total discounts applied to the price of the order in shop and presentment currencies.
        /// </summary>
        [JsonPropertyName("total_discounts_set")]
        public MoneyBag? TotalDiscountsSet { get; set; }

        /// <summary>
        /// The sum of all the prices of all the items in the order.
        /// </summary>
        [JsonPropertyName("total_line_items_price")]
        public decimal? TotalLineItemsPrice { get; set; }

        /// <summary>
        /// The total of all line item prices in shop and presentment currencies.
        /// </summary>
        [JsonPropertyName("total_line_items_price_set")]
        public MoneyBag? TotalLineItemsPriceSet { get; set; }

        /// <summary>
        /// The total outstanding amount of the order in the shop currency.
        /// </summary>
        [JsonPropertyName("total_outstanding")]
        public decimal? TotalOutstanding { get; set; }

        /// <summary>
        /// The sum of all the prices of all the items in the order, with taxes and discounts included (must be positive).
        /// </summary>
        [JsonPropertyName("total_price")]
        public decimal? TotalPrice { get; set; }

        /// <summary>
        /// Confirmed order.
        /// </summary>
        [JsonPropertyName("confirmed")]
        public bool Confirmed { get; set; }

        /// <summary>
        /// The total price of the order in shop and presentment currencies.
        /// </summary>
        [JsonPropertyName("total_price_set")]
        public MoneyBag? TotalPriceSet { get; set; }

        /// <summary>
        /// Total USD price.
        /// </summary>
        [JsonPropertyName("total_price_usd")]
        public decimal? TotalPriceUsd { get; set; }

        /// <summary>
        /// The total shipping price of the order, excluding discounts and returns, in shop and presentment currencies.
        /// If taxes_included is set to true, then total_shipping_price_set includes taxes.
        /// </summary>
        [JsonPropertyName("total_shipping_price_set")]
        public MoneyBag? TotalShippingPriceSet { get; set; }

        /// <summary>
        /// The sum of all the taxes applied to the order (must be positive).
        /// </summary>
        [JsonPropertyName("total_tax")]
        public decimal? TotalTax { get; set; }

        /// <summary>
        /// The total tax applied to the order in shop and presentment currencies.
        /// </summary>
        [JsonPropertyName("total_tax_set")]
        public MoneyBag? TotalTaxSet { get; set; }

        /// <summary>
        /// The sum of all the tips in the order.
        /// </summary>
        [JsonPropertyName("total_tip_received")]
        public decimal? TotalTipReceived { get; set; }

        /// <summary>
        /// The sum of all the weights of the line items in the order, in grams.
        /// </summary>summary>
        [JsonPropertyName("total_weight")]
        public long? TotalWeight { get; set; }

        /// <summary>
        /// The date and time when the order was last modified.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// The unique numerical identifier for the user logged into the terminal at the time the order was processed at. Only present on orders processed at point of sale.
        /// </summary>
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// The URL pointing to the order status web page, if applicable.
        /// </summary>
        [JsonPropertyName("order_status_url")]
        public string? OrderStatusUrl { get; set; }
    }
}
