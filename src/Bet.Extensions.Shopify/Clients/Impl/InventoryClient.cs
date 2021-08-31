using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Abstractions.Options;
using Bet.Extensions.Shopify.Models.Inventory;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bet.Extensions.Shopify.Clients.Impl
{
    public class InventoryClient : IInventoryClient
    {
        private readonly IShopifyClient _shopifyClient;
        private readonly ShopifyOptions _options;
        private readonly ILogger<InventoryClient> _logger;

        public InventoryClient(
            IShopifyClient shopifyClient,
            IOptions<ShopifyOptions> options,
            ILogger<InventoryClient> logger)
        {
            _shopifyClient = shopifyClient;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IEnumerable<Location>?> GetLocationsAsync(CancellationToken cancellationToken = default)
        {
            var requestUri = "locations.json";

            var response = await _shopifyClient.GetAsync<IEnumerable<Location>>(requestUri, "locations", cancellationToken: cancellationToken);

            return response.Payload;
        }
    }
}
