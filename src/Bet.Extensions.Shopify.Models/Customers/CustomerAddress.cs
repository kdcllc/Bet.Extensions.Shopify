using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Customers
{
    /// <summary>
    /// <para>The Shopify API lets you do the following with the Customer Address resource. More detailed versions of these general actions may be available:</para>
    /// <para>
    /// GET /admin/api/2021-07/customers/{customer_id}/addresses.json
    /// Retrieves a list of addresses for a customer.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/customers/{customer_id}/addresses/{address_id}.json
    /// Retrieves details for a single customer address.
    /// </para>
    /// <para>
    /// POST /admin/api/2021-07/customers/{customer_id}/addresses.json
    /// Creates a new address for a customer.
    /// </para>
    /// <para>
    /// PUT /admin/api/2021-07/customers/{customer_id}/addresses/{address_id}.json
    /// Updates an existing customer address.
    /// </para>
    /// <para>
    /// DELETE /admin/api/2021-07/customers/{customer_id}/addresses/{address_id}.json
    /// Removes an address from a customer’s address list.
    /// </para>
    /// <para>
    /// PUT /admin/api/2021-07/customers/{customer_id}/addresses/set.json?address_ids[]=1053317294&operation=destroy
    /// Performs bulk operations for multiple customer addresses.
    /// </para>
    /// <para>
    /// PUT /admin/api/2021-07/customers/{customer_id}/addresses/{address_id}/default.json
    /// Sets the default address for a customer.
    /// </para>
    ///
    /// <para>
    ///    <see href="https://shopify.dev/api/admin/rest/reference/customers/customer-address"/>.
    /// </para>
    /// </summary>
    public class CustomerAddress : Address
    {
        /// <summary>
        /// An unique id for the Customer.
        /// </summary>
        [JsonPropertyName("customer_id")]
        public long? CustomerId { get; set; }
    }
}
