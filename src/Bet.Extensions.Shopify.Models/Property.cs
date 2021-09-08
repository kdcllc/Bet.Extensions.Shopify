using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models
{
    /// <summary>
    /// An object representing a property.
    /// </summary>
    public class Property
    {
        /// <summary>
        /// The name of the note attribute.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The value of the note attribute.
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}
