using System.Text.Json;

namespace Bet.Extensions.Shopify.Models
{
    public static class SystemTextJson
    {
        public static JsonSerializerOptions Options => new ()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() },
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals,

            // Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            // Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true,
        };
    }
}
