using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Models;

using Microsoft.Extensions.Logging;

namespace Bet.Extensions.Shopify.Clients.Impl
{
    internal class ShopifyBaseClient : IShopifyBaseClient
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<ShopifyBaseClient> _logger;

        public ShopifyBaseClient(
            HttpClient httpClient,
            ILogger<ShopifyBaseClient> logger)
        {
            _httpClient = httpClient ?? throw new System.ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public HttpClient HttpClient => _httpClient;

        public async Task<PagedResponse<T>> ListAsync<T>(
            string requestUri,
            string? rootElement = null,
            IList<KeyValuePair<string, object>>? parameters = null,
            CancellationToken cancellationToken = default)
        {
            var url = parameters.CompileRequestUri(requestUri);

            var response = await _httpClient.GetAsync(url, cancellationToken);
            response.EnsureSuccessStatusCode();

            // Link: <https://{shop}.myshopify.com/admin/api/2021-07/products.json?limit=250&page_info=eyJ2ZW5kb3IiO>; rel="next"
            var pageInfo = response.GetPageInfo();

            if (!string.IsNullOrEmpty(rootElement))
            {
                using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                if (stream != null)
                {
                    var json = (await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken)).RootElement.GetProperty(rootElement).GetRawText();

                    var result = JsonSerializer.Deserialize<T>(json, SystemTextJson.Options);
                    return new PagedResponse<T>(result, pageInfo);
                }
            }
            else
            {
                // https://github.com/dotnet/runtime/blob/57bfe474518ab5b7cfe6bf7424a79ce3af9d6657/src/libraries/System.Net.Http.Json/src/System/Net/Http/Json/HttpClientJsonExtensions.Get.cs#L170
                var result = await response.Content.ReadFromJsonAsync<T>(SystemTextJson.Options, cancellationToken);
                return new PagedResponse<T>(result, pageInfo);
            }

            return new PagedResponse<T>();
        }

        public async Task<IEnumerable<T>> ListAllAsync<T>(
            string requestUri,
            string? rootElement = null,
            IList<KeyValuePair<string, object>>? parameters = null,
            CancellationToken cancellationToken = default)
        {
            var list = new List<T>();
            var recordCount = 0;
            var nextPage = string.Empty;

            // loop thru till no longer page info is returned
            do
            {
                var result = await ListAsync<IEnumerable<T>>(requestUri, rootElement, parameters, cancellationToken);
                nextPage = result.NextPageInfo;
                if (result?.Payload != null)
                {
                    list.AddRange(result.Payload);
                }

                recordCount += result?.Payload?.Count() ?? 0;

                if (!string.IsNullOrEmpty(nextPage)
                    && parameters != null)
                {
                    var limit = parameters.FirstOrDefault(x => x.Key == "limit");

                    parameters = new List<KeyValuePair<string, object>>
                    {
                        new KeyValuePair<string, object>("page_info", nextPage)
                    };
                    if (limit.Key != null)
                    {
                        parameters.Add(limit);
                    }
                }
            }
            while (!string.IsNullOrEmpty(nextPage));

            _logger.LogDebug("{requestUri} - {recordCount}", requestUri, recordCount);
            return list;
        }

        public async Task<T?> ExecuteAsync<T>(
            string requestUri,
            IList<KeyValuePair<string, object>>? parameters = null,
            string? rootElement = null,
            HttpContent? content = null,
            HttpMethod? httpMethod = null,
            CancellationToken cancellationToken = default)
        {
            var url = parameters.CompileRequestUri(requestUri);

            var requestMessage = new HttpRequestMessage(httpMethod ?? HttpMethod.Get, url)
            {
                Content = content
            };

            var response = await _httpClient.SendAsync(requestMessage, cancellationToken);
            response.EnsureSuccessStatusCode();

            if (!string.IsNullOrEmpty(rootElement))
            {
                using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                if (stream != null)
                {
                    var json = (await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken)).RootElement.GetProperty(rootElement).GetRawText();

                    return JsonSerializer.Deserialize<T>(json, SystemTextJson.Options);
                }
            }

            return await response.Content.ReadFromJsonAsync<T>(SystemTextJson.Options, cancellationToken);
        }

        public async Task DeleteAsync(string requestUri, CancellationToken cancellationToken)
        {
            await _httpClient.DeleteAsync(requestUri, cancellationToken);
        }
    }
}
