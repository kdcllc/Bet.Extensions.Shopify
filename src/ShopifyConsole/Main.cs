using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Abstractions.Options;
using Bet.Extensions.Shopify.Clients;
using Bet.Extensions.Shopify.Models.Products;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ShopifyConsole
{
    public class Main : IMain
    {
        private readonly ILogger<Main> _logger;
        private readonly IInventoryClient _inventory;
        private readonly IShopifyClient _shopifyService;
        private readonly ShopifyOptions _options;
        private readonly IHostApplicationLifetime _applicationLifetime;

        public IConfiguration Configuration { get; set; }

        public Main(
            IInventoryClient inventory,
            IShopifyClient shopifyService,
            IOptions<ShopifyOptions> options,
            IHostApplicationLifetime applicationLifetime,
            IConfiguration configuration,
            ILogger<Main> logger)
        {
            _inventory = inventory;
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

            // var invt = await _inventory.GetLocationsAsync(cancellationToken);

            var kvb = new List<KeyValuePair<string, object>>
            {
               // new KeyValuePair<string, string>("limit", "250"),
                new KeyValuePair<string, object>("vendor", "Husky"),
            };

            var productsQuery = "products.json";

            var products = await _shopifyService.GetAllAsync<Product>(productsQuery, "products", kvb, cancellationToken);

            return 0;
        }
    }
}
