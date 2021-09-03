using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify
{
    public static class SystemTextJson
    {
        public static JsonSerializerOptions Options => new ()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() },
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals,

            //Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            // Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true,
        };
    }
}
