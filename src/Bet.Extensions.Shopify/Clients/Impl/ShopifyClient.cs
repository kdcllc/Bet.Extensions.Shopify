using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Models;

using Microsoft.Extensions.Logging;

namespace Bet.Extensions.Shopify.Clients.Impl
{
    public class ShopifyClient : IShopifyClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ShopifyClient> _logger;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1204:Static elements should appear before instance elements", Justification = "Make sense here")]
        private static readonly JsonSerializerOptions _serializeOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() },
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals,
            //Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            // Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true,
        };

        public ShopifyClient(
            HttpClient httpClient,
            ILogger<ShopifyClient> logger)
        {
            _httpClient = httpClient ?? throw new System.ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task<PagedResponse<T>> GetAsync<T>(
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

                    var result = JsonSerializer.Deserialize<T>(json, _serializeOptions);
                    return new PagedResponse<T>(result, pageInfo);
                }
            }
            else
            {
                // https://github.com/dotnet/runtime/blob/57bfe474518ab5b7cfe6bf7424a79ce3af9d6657/src/libraries/System.Net.Http.Json/src/System/Net/Http/Json/HttpClientJsonExtensions.Get.cs#L170
                var result = await response.Content.ReadFromJsonAsync<T>(_serializeOptions, cancellationToken);
                return new PagedResponse<T>(result, pageInfo);
            }

            return new PagedResponse<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(
            string requestUri,
            string? rootElement = null,
            IList<KeyValuePair<string, object>>? parameters = null,
            CancellationToken cancellationToken = default)
        {
            var list = new List<T>();
            var recordCount = 0;
            var nextPage = string.Empty;

            do
            {
                var result = await GetAsync<IEnumerable<T>>(requestUri, rootElement, parameters, cancellationToken);
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
    }
}
