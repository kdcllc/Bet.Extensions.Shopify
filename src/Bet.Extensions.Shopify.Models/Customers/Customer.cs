namespace Bet.Extensions.Shopify.Models.Customers;

/// <summary>
/// <para>The Shopify API lets you do the following with the Customer resource. More detailed versions of these general actions may be available:</para>
/// <para>
/// GET /admin/api/2021-07/customers.json
/// Retrieves a list of customers.
/// </para>
/// <para>
/// GET /admin/api/2021-07/customers/search.json?query=Bob country:United States
/// Searches for customers that match a supplied query.
/// </para>
/// <para>
/// GET /admin/api/2021-07/customers/{customer_id}.json
/// Retrieves a single customer.
/// </para>
/// <para>
/// POST /admin/api/2021-07/customers.json
/// Creates a customer.
/// </para>
/// <para>
/// PUT /admin/api/2021-07/customers/{customer_id}.json
/// Updates a customer.
/// </para>
/// <para>
/// POST /admin/api/2021-07/customers/{customer_id}/account_activation_url.json
/// Creates an account activation URL for a customer.
/// </para>
/// <para>
/// POST /admin/api/2021-07/customers/{customer_id}/send_invite.json
/// Sends an account invite to a customer.
/// </para>
/// <para>
/// DELETE /admin/api/2021-07/customers/{customer_id}.json
/// Deletes a customer.
/// </para>
/// <para>
/// GET /admin/api/2021-07/customers/count.json
/// Retrieves a count of customers.
/// </para>
/// <para>
/// GET /admin/api/2021-07/customers/{customer_id}/orders.json
/// Retrieves all orders belonging to a customer.
/// </para>
/// <para><see href="https://shopify.dev/api/admin/rest/reference/customers/customer#what-you-can-do-with-customer-2021-07"/>.</para>
/// </summary>
public class Customer : BaseModel
{
    /// <summary>
    /// <para>Whether the customer has consented to receive marketing material via email.</para>
    /// <para>
    /// <code>
    /// "accepts_marketing": false
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("accepts_marketing")]
    public bool? AcceptsMarketing { get; set; }

    /// <summary>
    /// <para>The date and time (ISO 8601 format) when the customer consented or objected to receiving marketing material by email.</para>
    /// <para>Set this value whenever the customer consents or objects to marketing materials.</para>
    /// <para>
    /// <code>
    /// "accepts_marketing_updated_at": "2013-06-27T08:48:27-04:00"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("accepts_marketing_updated_at")]
    public DateTimeOffset? AcceptsMarketingUpdatedAt { get; set; }

    /// <summary>
    /// <para>A list of the ten most recently updated addresses for the customer.</para>
    /// <para>
    /// <code>
    /// "addresses": [
    /// {
    ///     "id": 207119551,
    ///     "customer_id": 6940095564,
    ///     "first_name": "Bob",
    ///     "last_name": "Norman",
    ///     "company": null,
    ///     "address1": "Chestnut Street 92",
    ///     "address2": "Apartment 2",
    ///     "city": "Louisville",
    ///     "province": "Kentucky",
    ///     "country": "United States",
    ///     "zip": "40202",
    ///     "phone": "555-625-1199",
    ///     "province_code": "KY",
    ///     "country_code": "US",
    ///     "country_name": "United States",
    ///     "default": true
    /// }
    /// ]
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("addresses")]
    public IEnumerable<CustomerAddress>? Addresses { get; set; }

    /// <summary>
    /// <para>The three-letter code (ISO 4217 format) for the currency that the customer used when they paid for their last order.</para>
    /// <para>Defaults to the shop currency. Returns the shop currency for test orders.</para>
    /// <para>
    /// <code>
    /// "currency": "JPY"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// <para>The date and time (ISO 8601 format) when the customer was created.</para>
    /// <para>
    /// <code>
    /// "created_at": "2013-06-27T08:48:27-04:00"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// <para>The default address for the customer.</para>
    /// <para>
    /// <code>
    /// "default_address": {
    /// "address1": "Chestnut Street 92",
    /// "address2": "Apartment 2",
    /// "city": "Louisville",
    /// "company": null,
    /// "country": "united states",
    /// "first_name": "Bob",
    /// "id": 207119551,
    /// "last_name": "Norman",
    /// "phone": "555-625-1199",
    /// "province": "Kentucky",
    /// "zip": "40202",
    /// "province_code": "KY",
    /// "country_code": "US",
    /// "country_name": "United States",
    /// "default": true
    /// }
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("default_address")]
    public CustomerAddress? DefaultAddress { get; set; }

    /// <summary>
    /// <para>The unique email address of the customer. Attempting to assign the same email address to multiple customers returns an error.</para>
    /// <para>
    /// <code>
    /// "email": "bob.norman@hostmail.com"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// <para>The customer's first name.</para>
    /// <para>
    /// <code>
    /// "first_name": "John"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>
    /// <para>The customer's last name.</para>
    /// <para>
    /// <code>
    /// "last_name": "Norman"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// <para>The id of the customer's last order.</para>
    /// <para>
    /// <code>
    /// "last_order_id": 234132602919
    /// </code>
    /// </para>
    /// </summary>
    /// <remarks>Property can be null or longer than max int32 value. Set to nullable long instead.</remarks>
    [JsonPropertyName("last_order_id")]
    public long? LastOrderId { get; set; }

    /// <summary>
    /// <para>The name of the customer's last order. This is directly related to the name field on the Order resource.</para>
    /// <para>
    /// <code>
    /// "last_order_name": "#1169"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("last_order_name")]
    public string? LastOrderName { get; set; }

    /// <summary>
    /// <para>Attaches additional metadata to a shop's resources:</para>
    /// <para>key (required): An identifier for the metafield (maximum of 30 characters).</para>
    /// <para>namespace(required): A container for a set of metadata (maximum of 20 characters). Namespaces help distinguish between metadata that you created and metadata created by another individual with a similar namespace.</para>
    /// <para>value (required): Information to be stored as metadata.</para>
    /// <para>value_type (required): The value type. Valid values: string and integer.</para>
    /// <para>description (optional): Additional information about the metafield.</para>
    /// </summary>
    [JsonPropertyName("metafields")]
    public IEnumerable<MetaField>? Metafields { get; set; }

    /// <summary>
    /// <para>The marketing subscription opt-in level (as described by the M3AAWG best practices guideline) that the customer gave when they consented to receive marketing material by email.</para>
    /// <para>If the customer does not accept email marketing, then this property will be set to null. Valid values:</para>
    /// <para>
    ///    single_opt_in
    ///    confirmed_opt_in
    ///    unknown.
    /// </para>
    ///
    /// <para>
    /// <code>
    /// "marketing_opt_in_level": "single_opt_in"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("marketing_opt_in_level")]
    public string? MarketingOptInLevel { get; set; }

    /// <summary>
    /// <para>A unique identifier for the customer that's used with ' 'Multipass login.</para>
    /// <para>
    /// <code>
    /// "multipass_identifier": null
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("multipass_identifier")]
    public string? MultipassIdentifier { get; set; }

    /// <summary>
    /// <para>A note about the customer.</para>
    /// <para>
    /// <code>
    /// "note": "Placed an order that had a fraud warning"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// <para>The number of orders associated with this customer.</para>
    /// <para>
    /// <code>
    /// "orders_count": 3
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("orders_count")]
    public int? OrdersCount { get; set; }

    /// <summary>
    /// <para>The unique phone number (E.164 format) for this customer.</para>
    /// <para>Attempting to assign the same phone number to multiple customers returns an error.</para>
    /// <para>The property can be set using different formats, but each format must represent a number that can be dialed from anywhere in the world.</para>
    /// <para>The following formats are all valid:</para>
    /// <para>6135551212.</para>
    /// <para>+16135551212.</para>
    /// <para>
    /// (613)555-1212
    /// +1 613-555-1212.
    /// </para>
    /// <para>
    /// <code>
    /// "phone": "+16135551111"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    /// <summary>
    /// <para>The state of the customer's account with a shop. Default value: disabled. Valid values:</para>
    /// <para>disabled: The customer doesn't have an active account. Customer accounts can be disabled from the Shopify admin at any time.</para>
    /// <para>invited: The customer has received an email invite to create an account.</para>
    /// <para>enabled: The customer has created an account.</para>
    /// <para>
    /// declined: The customer declined the email invite to create an account.
    /// <code>
    /// "state": "disabled"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// <para>Tags that the shop owner has attached to the customer, formatted as a string of comma-separated values.</para>
    /// <para>A customer can have up to 250 tags. Each tag can have up to 255 characters.</para>
    /// <para>
    /// <code>
    /// "tags": "loyal"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("tags")]
    public string? Tags { get; set; }

    /// <summary>
    /// <para>Whether the customer is exempt from paying taxes on their order.</para>
    /// <para>If true, then taxes won't be applied to an order at checkout.</para>
    /// <para>If false, then taxes will be applied at checkout.</para>
    /// <para>
    /// <code>
    /// "tax_exempt": true
    /// </code>
    /// </para>
    ///
    /// </summary>
    [JsonPropertyName("tax_exempt")]
    public bool? TaxExempt { get; set; }

    /// <summary>
    /// Whether the customer is exempt from paying specific taxes on their order. Canadian taxes only.
    /// </summary>
    [JsonPropertyName("tax_exemptions")]
    public IEnumerable<string>? TaxExemptions { get; set; }

    /// <summary>
    /// <para>The total amount of money that the customer has spent across their order history.</para>
    /// <para>
    /// <code>
    /// "total_spent": "375.30"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("total_spent")]
    public decimal? TotalSpent { get; set; }

    /// <summary>
    /// <para>The date and time (ISO 8601 format) when the customer information was last updated.</para>
    /// <para>
    /// <code>
    /// "updated_at": "2012-08-24T14:01:46-04:00"
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// <para>Whether the customer has verified their email address.</para>
    /// <para>
    /// <code>
    /// "verified_email": true
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("verified_email")]
    public bool? VerifiedEmail { get; set; }
}
