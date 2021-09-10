using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

using Bet.Extensions.Shopify;

using Microsoft.AspNetCore.Http;

namespace ShopifyWeb
{
    public class ShopifyResult : IResult
    {
        private readonly object _data;

        public ShopifyResult(object data)
        {
            _data = data;
        }

        public async Task ExecuteAsync(HttpContext httpContext)
        {
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, _data, _data.GetType(), SystemTextJson.Options);
            var readOnlyMemory = new ReadOnlyMemory<byte>(stream.ToArray());

            httpContext.Response.ContentType = "application/json; charset=utf-8";
            httpContext.Response.StatusCode = StatusCodes.Status200OK;

            await httpContext.Response.Body.WriteAsync(readOnlyMemory);
            await httpContext.Response.Body.FlushAsync();
        }
    }
}
