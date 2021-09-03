using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Bet.Extensions.Shopify
{
    public class JsonContent : ByteArrayContent
    {
        public JsonContent(object data) : base(ToUtf8Bytes(data))
        {
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        private static byte[] ToUtf8Bytes(object data)
        {
            return JsonSerializer.SerializeToUtf8Bytes(data, data.GetType(), SystemTextJson.Options);
        }
    }
}
