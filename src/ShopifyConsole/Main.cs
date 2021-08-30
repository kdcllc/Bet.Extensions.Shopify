using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Abstractions.Options;
using Bet.Extensions.Shopify.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ShopifyConsole
{
    public class Main : IMain
    {
        private readonly ILogger<Main> _logger;
        private readonly IShopifyService _shopifyService;
        private readonly ShopifyOptions _options;
        private readonly IHostApplicationLifetime _applicationLifetime;

        public IConfiguration Configuration { get; set; }

        public Main(
            IShopifyService shopifyService,
            IOptions<ShopifyOptions> options,
            IHostApplicationLifetime applicationLifetime,
            IConfiguration configuration,
            ILogger<Main> logger)
        {
            _shopifyService = shopifyService;
            _options = options.Value;

            _applicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> RunAsync()
        {
            _logger.LogInformation("Main executed");

            // use this token for stopping the services
            var cancellationToken = _applicationLifetime.ApplicationStopping;
            cancellationToken.ThrowIfCancellationRequested();

            var query = new Dictionary<string, string>
            {
                {"limit", "1" },
                { "vendor", "Craftsman" }
            };

            var productsQuery = $"{_options.ShopUrl}/admin/api/{_options.Version}/products.json";

            var result = await _shopifyService.GetTaskAsync<dynamic>(productsQuery, new { queryString = query }, cancellationToken);
            var obj = JsonDocument.Parse(Convert.ToString(result));

            var propertyVal = obj.RootElement.GetProperty("products"); //.GetString();

            _logger.LogInformation($"{Convert.ToString(result)}");
            return 0;
        }
    }
}
