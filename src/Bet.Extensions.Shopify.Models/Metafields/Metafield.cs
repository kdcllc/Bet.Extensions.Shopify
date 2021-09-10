using System;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Metafields
{
    /// <summary>
    /// <para>The Shopify API lets you do the following with the Metafield resource. More detailed versions of these general actions may be available:</para>
    /// <para>
    /// GET /admin/api/2021-07/metafields.json
    /// Retrieves a list of metafields that belong to a resource.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/metafields.json?metafield[owner_id]=850703190&metafield[owner_resource]=product_image
    /// Retrieves a list of metafields that belong to a Product Image resource.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/metafields/count.json
    /// Retrieves a count of a resource's metafields.
    /// </para>
    /// <para>
    /// GET /admin/api/2021-07/metafields/{metafield_id}.json
    /// Retrieves a single metafield from a resource by its ID.
    /// </para>
    /// <para>
    /// POST /admin/api/2021-07/metafields.json
    /// Creates a new metafield for a resource.
    /// </para>
    /// <para>
    /// PUT /admin/api/2021-07/metafields/{metafield_id}.json
    /// Updates a metafield.
    /// </para>
    /// <para>
    /// DELETE /admin/api/2021-07/metafields/{metafield_id}.json
    /// Deletes a metafield by its ID.
    /// </para>
    /// <para><see href="https://shopify.dev/api/admin/rest/reference/metafield#what-you-can-do-with-metafield-2021-07"/>.</para>
    /// </summary>
    public class Metafield : BaseModel
    {
        /// <summary>
        /// <para>The date and time (ISO 8601 format) when the metafield was created.</para>
        /// <para>
        /// <code>
        /// "created_at": "2012-03-13T16:09:54-04:00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// <para>The date and time (ISO 8601 format) when the metafield was last updated.</para>
        /// <para>
        /// <code>
        /// "updated_at": "2012-08-24T14:02:15-04:00"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// <para>The name of the metafield. Minimum length: 3 characters. Maximum length: 30 characters.</para>
        /// <para>
        /// <code>
        /// "key": "warehouse"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        /// <summary>
        /// <para>The information to be stored as metadata.</para>
        /// <para>Maximum length: 512 characters when metafield namespace is equal to tags and key is equal to alt.</para>
        /// <para>When using type, see <see href="https://shopify.dev/apps/metafields/definitions/types"/>.</para>
        /// <para>When using the deprecated value_type, the maximum length of value varies:</para>
        /// <para>If value_type is a string, then maximum length: 5,000,000 characters.</para>
        /// <para>If value_type is an integer, then maximum length: 100,000 characters.</para>
        /// <para>If value_type is a json_string, then maximum length: 100,000 characters.</para>
        /// <para>
        /// <code>
        ///   "value": 25
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("value")]
        public object? Value { get; set; }

        /// <summary>
        /// <para>The metafield's information type. Valid values: string, integer, json_string.</para>
        /// <para>
        /// <code>
        ///  "value_type": "integer"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("value_type")]
        [Obsolete($" Use {nameof(Type)} instead")]
        public string? ValueType { get; set; }

        /// <summary>
        /// <para>
        /// The metafield's information type.
        /// <see href="https://shopify.dev/apps/metafields/definitions/types"/>.
        /// </para>
        /// <para>
        /// <code>
        /// "type": "single_line_text_field"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// <para>
        /// A container for a set of metafields.
        /// You need to define a custom namespace for your metafields to distinguish them from the metafields used by other apps.
        /// Minimum length: 2 characters. Maximum length: 20 characters.
        /// </para>
        /// <para>
        /// <code>
        /// "namespace": "inventory"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("namespace")]
        public string? Namespace { get; set; }

        /// <summary>
        /// <para>A description of the information that the metafield contains.</para>
        /// <para>
        /// <code>
        ///  "description": null
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// <para>The unique ID of the resource that the metafield is attached to.</para>
        /// <para>
        /// <code>
        /// "owner_id": 690933842
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("owner_id")]
        public long? OwnerId { get; set; }

        /// <summary>
        /// <para>The type of resource that the metafield is attached to.</para>
        /// <para>
        /// <code>
        /// "owner_resource": "product"
        /// </code>
        /// </para>
        /// </summary>
        [JsonPropertyName("owner_resource")]
        public string? OwnerResource { get; set; }
    }
}
