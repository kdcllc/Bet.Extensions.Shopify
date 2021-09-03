using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Bet.AspNetCore.Shopify.Middleware.Hmac.Options;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IO;

namespace Bet.AspNetCore.Shopify.Services.Impl
{
    public class HmacValidator : IHmacValidator
    {
        private const int ReadChunkBufferLength = 4096;

        private readonly HmacValidationOptions _options;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;

        public HmacValidator(IOptions<HmacValidationOptions> options)
        {
            _options = options.Value;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task<bool> ValidateAsync(HttpRequest request)
        {
            if (request.Headers.TryGetValue(_options.ShopifyHmacHeaderName, out var headerValues))
            {
                var headerValue = headerValues.First();

                var requestBody = await GetRequestBody(request);

                var keyBytes = Encoding.UTF8.GetBytes(_options.SharedSecret);
                var dataBytes = Encoding.UTF8.GetBytes(requestBody);

                // use the SHA256Managed Class to compute the hash
                var hmac = new HMACSHA256(keyBytes);
                var hmacBytes = hmac.ComputeHash(dataBytes);

                // return as base64 string. Compared with the signature passed in the header of the post request from Shopify.
                // If they match, the call is verified.
                var createSignature = Convert.ToBase64String(hmacBytes);

                return headerValue.Equals(createSignature);
            }

            return false;
        }

        private async Task<string> GetRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            using var requestStream = _recyclableMemoryStreamManager.GetStream();

            await request.Body.CopyToAsync(requestStream);
            request.Body.Seek(0, SeekOrigin.Begin);
            return ReadStreamInChunks(requestStream);
        }

        private string ReadStreamInChunks(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);

            var readChunk = new char[ReadChunkBufferLength];
            int readChunkLength;

            // do while: is useful for the last iteration in case readChunkLength < chunkLength
            do
            {
                readChunkLength = reader.ReadBlock(readChunk, 0, ReadChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            }
            while (readChunkLength > 0);

            return textWriter.ToString();
        }
    }
}
