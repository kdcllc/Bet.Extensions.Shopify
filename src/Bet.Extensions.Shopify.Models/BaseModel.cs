using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models
{
    public abstract class BaseModel
    {
        /// <summary>
        /// The object's unique id.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("admin_graphql_api_id")]
        public string? AdminGraphQLAPIId { get; set; }
    }
}
