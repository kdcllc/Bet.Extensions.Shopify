using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Models.Inventory;

namespace Bet.Extensions.Shopify.Clients.Impl
{
    public class InventoryClient : IInventoryClient
    {
        private readonly IShopifyClient _shopifyClient;

        public InventoryClient(IShopifyClient shopifyClient)
        {
            _shopifyClient = shopifyClient ?? throw new System.ArgumentNullException(nameof(shopifyClient));
        }

        public async Task<IEnumerable<Location>?> GetLocationsAsync(CancellationToken cancellationToken = default)
        {
            var requestUri = "locations.json";

            var response = await _shopifyClient.ListAsync<IEnumerable<Location>>(requestUri, "locations", cancellationToken: cancellationToken);

            return response.Payload;
        }
    }
}
