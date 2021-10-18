using Bet.Extensions.Shopify.Models.Customers;

namespace Bet.Extensions.Shopify.Models.Queries.Customers;

/// <summary>
/// <para>Query Shopify for <see cref="Customer"/> endpoint.</para>
/// <para><see href="https://shopify.dev/api/admin/rest/reference/customers/customer#endpoints-2021-07"/>.</para>
///
/// <code>
/// /admin/api/2021-07/customers/search.json?query=Bob country:United States
/// </code>
/// </summary>
public class CustomerSearchQuery : PageInfoQuery
{
    /// <summary>
    /// <para>Set the field and direction by which to order results.</para>
    /// <para>
    /// <code>
    /// (default: last_order_date DESC)
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("order")]
    public string? Order { get; set; }

    /// <summary>
    /// <para>Text to search for in the shop's customer data.</para>
    /// <para>Note: Supported queries:</para>
    /// <para>
    /// accepts_marketing,
    /// activation_date,
    /// address1,
    /// address2,
    /// city,
    /// company,
    /// country,
    /// customer_date,
    /// customer_first_name,
    /// customer_id,
    /// customer_last_name,
    /// customer_tag,
    /// email,
    /// email_marketing_state,
    /// first_name,
    /// first_order_date,
    /// id,
    /// last_abandoned_order_date,
    /// last_name,
    /// multipass_identifier,
    /// orders_count,
    /// order_date,
    /// phone,
    /// province,
    /// shop_id,
    /// state,
    /// tag,
    /// total_spent,
    /// updated_at,
    /// verified_email,
    /// product_subscriber_status.
    /// </para>
    /// <para>All other queries returns all customers.</para>
    /// <para>
    /// <code>
    /// GET /admin/api/2021-07/customers/search.json?query=Bob country:United States
    /// </code>
    /// </para>
    /// </summary>
    [JsonPropertyName("query")]
    public string? Query { get; set; }

    /// <summary>
    /// Return only certain fields specified by a comma-separated list of field names.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<string>? Fields { get; set; }
}
