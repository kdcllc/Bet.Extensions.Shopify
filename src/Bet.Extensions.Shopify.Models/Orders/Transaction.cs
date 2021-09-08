using System;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Orders
{
    /// <summary>
    /// <para>The Shopify API lets you do the following with the Transaction resource. More detailed versions of these general actions may be  available:</para>
    /// <para>
    /// GET /admin/api/2021-07/orders/{order_id}/transactions.json
    /// Retrieves a list of transactions.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/orders/{order_id}/transactions/count.json
    /// Retrieves a count of an order's transactions.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/orders/{order_id}/transactions/{transaction_id}.json
    /// Retrieves a specific transaction.
    /// </para>
    /// <para>
    /// POST /admin/api/2021-07/orders/{order_id}/transactions.json
    /// Creates a transaction for an order.
    /// </para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/orders/transaction#properties-2021-07"/>.</para>
    /// </summary>
    public class Transaction : BaseModel
    {
        /// <summary>
        /// <para>The amount of money included in the transaction.</para>
        /// <para>If you don't provide a value for `amount`, then it defaults to the total cost of the order (even if a previous transaction has been made towards it).</para>
        /// <para>
        /// <code>
        /// "amount": "10.00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// <para>
        /// The authorization code associated with the transaction.</para>
        /// <para>
        /// <code>
        /// "authorization": "ch_1AtJu6CktlpKSclI4zjeQb2t"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("authorization")]
        public string? Authorization { get; set; }

        /// <summary>
        /// <para>The date and time (ISO 8601 format) when the Shopify Payments authorization expires.</para>
        /// <para>
        /// <code>
        ///  "authorization_expires_at": "2021-03-13T16:09:54-04:00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("authorization_expires_at")]
        public DateTimeOffset? AuthorizationExpiresAt { get; set; }

        /// <summary>
        /// <para>The date and time (ISO 8601 format) when the transaction was created.</para>
        /// <para>
        /// <code>
        /// "created_at": "2012-03-13T16:09:54-04:00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// <para>
        /// The ID for the device.</para>
        /// <para>
        /// <code>
        ///  "device_id": 1
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("device_id")]
        public int? DeviceId { get; set; }

        /// <summary>
        /// The name of the gateway the transaction was issued through.
        /// </summary>
        [JsonPropertyName("gateway")]
        public string Gateway { get; set; }

        /// <summary>
        /// The origin of the transaction. This is set by Shopify and cannot be overridden. Example values include: 'web', 'pos', 'iphone', 'android'.
        /// </summary>
        [JsonPropertyName("source_name")]
        public string SourceName { get; private set; }

        /// <summary>
        /// The origin of the transaction. Set to "external" to create a cash transaction for the associated order.
        /// </summary>
        [JsonPropertyName("source")]
        public string Source { get; set; }

        /// <summary>
        /// An object containing information about the credit card used for this transaction.
        /// </summary>
        [JsonPropertyName("payment_details")]
        public PaymentDetails PaymentDetails { get; set; }

        /// <summary>
        /// The kind of transaction. Known values are 'authorization', 'capture', 'sale', 'void' and 'refund'.
        /// </summary>
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        /// <summary>
        /// A unique numeric identifier for the order.
        /// </summary>
        [JsonPropertyName("order_id")]
        public long? OrderId { get; set; }

        /// <summary>
        /// Shopify does not currently offer documentation for this object.
        /// </summary>
        [JsonPropertyName("receipt")]
        public object Receipt { get; set; }

        /// <summary>
        /// <para>A standardized error code, independent of the payment provider. Valid values:</para>
        /// <para>incorrect_number</para>
        /// <para>invalid_number</para>
        /// <para>invalid_expiry_date</para>
        /// <para>invalid_cvc</para>
        /// <para>expired_card</para>
        /// <para>incorrect_cvc</para>
        /// <para>incorrect_zip</para>
        /// <para>incorrect_address</para>
        /// <para>card_declined</para>
        /// <para>processing_error</para>
        /// <para>call_issuer</para>
        /// <para>pick_up_card</para>
        /// <para>
        /// <code>
        /// "error_code": "invalid_cvc"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("error_code")]
        public string? ErrorCode { get; set; }

        /// <summary>
        /// The status of the transaction. Valid values are: pending, failure, success or error.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Whether the transaction is for testing purposes.
        /// </summary>
        [JsonPropertyName("test")]
        public bool? Test { get; set; }

        /// <summary>
        /// The unique identifier for the user.
        /// </summary>
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// <para>The three-letter code (ISO 4217 format) for the currency used for the payment.</para>
        /// <para>
        /// <code>
        ///  "currency": "USD"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("location_id")]
        public long? LocationId { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("parent_id")]
        public long? ParentId { get; set; }

        /// <summary>
        /// The maximum amount that can be refunded.
        /// </summary>
        [JsonPropertyName("maximum_refundable")]
        public decimal? MaximumRefundable { get; set; }

        /// <summary>
        /// An adjustment on the transaction showing the amount lost or gained due to fluctuations in the currency exchange rate
        /// Requires the header X-Shopify-Api-Features = include-currency-exchange-adjustments.
        /// </summary>
        [JsonPropertyName("currency_exchange_adjustment")]
        public CurrencyExchangeAdjustment CurrencyExchangeAdjustment { get; set; }
    }
}
