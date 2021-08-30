using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace Bet.Extensions.Shopify.Services.Impl
{
    public class ShopifyService : IShopifyService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ShopifyService> _logger;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1204:Static elements should appear before instance elements", Justification = "Make sense here")]
        private static readonly JsonSerializerOptions _serializeOptions = new ()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonStringEnumConverter() },
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals,
            WriteIndented = true
        };

        public ShopifyService(
            HttpClient httpClient,
            ILogger<ShopifyService> logger)
        {
            _httpClient = httpClient ?? throw new System.ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public async Task<(T? result, string pageInfo)> GetTaskAsync<T>(string url, object? parameters, CancellationToken cancellationToken)
        {
            IDictionary<string, string>? queryParam;
            var query = string.Empty;

            if (parameters?.GetType().GetProperty("queryString") != null)
            {
                queryParam = parameters?.GetType().GetProperty("queryString")?.GetValue(parameters) as IDictionary<string, string>;

                if (queryParam != null)
                {
                    query = "?";

                    foreach (var item in queryParam)
                    {
                        query += $"&{item.Key}={Uri.EscapeDataString(item.Value)}";
                    }
                }
            }

            var response = await _httpClient.GetAsync($"{url}{query}", cancellationToken);
            response.EnsureSuccessStatusCode();

            // Link: <https://{shop}.myshopify.com/admin/api/2021-07/products.json?limit=250&page_info=eyJ2ZW5kb3IiO>; rel="next"
            var link = response.Headers.GetValues("Link").FirstOrDefault();
            var pageInfo = string.Empty;

            if (link != null)
            {
                foreach (var content in link.Split(","))
                {
                    if (content.Contains("next"))
                    {
                        pageInfo = content.Split(";")[0].TrimStart('<').TrimEnd('>').Split("page_info=")[1];
                    }
                }
            }

            // https://github.com/dotnet/runtime/blob/57bfe474518ab5b7cfe6bf7424a79ce3af9d6657/src/libraries/System.Net.Http.Json/src/System/Net/Http/Json/HttpClientJsonExtensions.Get.cs#L170
            var result = await response.Content.ReadFromJsonAsync<T>(_serializeOptions, cancellationToken);

            return (result, pageInfo);
        }
    }
}
