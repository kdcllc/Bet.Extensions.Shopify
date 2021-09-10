using System;
using System.Text.Json.Serialization;

using Bet.Extensions.Shopify.Models.Metafields;

namespace Bet.Extensions.Shopify.Models.Queries.Metafields
{
    /// <summary>
    /// Query Shopify <see cref="Metafield"/> endpoint.
    ///
    /// <see href="https://shopify.dev/api/admin/rest/reference/metafield#endpoints-2021-07"/>.
    /// </summary>
    public class MetafieldQuery : PageInfoQuery
    {
        /// <summary>
        /// Restrict results to after the specified ID.
        /// </summary>
        [JsonPropertyName("since_id")]
        public long? SinceId { get; set; }

        /// <summary>
        /// Return created after a specified date. (format: 2014-04-25T16:15:47-04:00).
        /// </summary>
        [JsonPropertyName("created_at_min")]
        public DateTimeOffset? CreatedAtMin { get; set; }

        /// <summary>
        /// Return created before a specified date. (format: 2014-04-25T16:15:47-04:00).
        /// </summary>
        [JsonPropertyName("created_at_max")]
        public DateTimeOffset? CreatedAtMax { get; set; }

        /// <summary>
        /// Return last updated after a specified date. (format: 2014-04-25T16:15:47-04:00).
        /// </summary>
        [JsonPropertyName("updated_at_min")]
        public DateTimeOffset? UpdatedAtMin { get; set; }

        /// <summary>
        /// Return last updated before a specified date. (format: 2014-04-25T16:15:47-04:00).
        /// </summary>
        [JsonPropertyName("updated_at_max")]
        public DateTimeOffset? UpdatedAtMax { get; set; }

        /// <summary>
        /// Show metafields with given namespace.
        /// </summary>
        [JsonPropertyName("namespace")]
        public string? Namespace { get; set; }

        /// <summary>
        /// Show metafields with given key.
        /// </summary>
        [JsonPropertyName("key")]
        public string? Key { get; set; }

        /// <summary>
        /// <para>The metafield's information type.</para>
        /// <para>string: Show only metafields with string value types</para>
        /// <para>integer: Show only metafields with integer value types</para>
        /// <para>json_string: Show only metafields with json_string value types.</para>
        /// </summary>
        [JsonPropertyName("value_type")]
        [Obsolete($"Use {nameof(Type)} instead")]
        public string? ValueType { get; set; }

        /// <summary>
        /// The metafield's information type.
        /// <see href="https://shopify.dev/apps/metafields/definitions/types"/>.
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
