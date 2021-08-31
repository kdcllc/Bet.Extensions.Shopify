using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Abstractions.Options;
using Bet.Extensions.Shopify.Models.Products;
using Bet.Extensions.Shopify.Queries;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bet.Extensions.Shopify.Clients.Impl
{
    public class ProductClient
    {
        private readonly IShopifyClient _shopifyClient;
        private readonly ShopifyOptions _options;
        private readonly ILogger<ProductClient> _logger;

        public ProductClient(
            IShopifyClient shopifyClient,
            IOptions<ShopifyOptions> options,
            ILogger<ProductClient> logger)
        {
            _shopifyClient = shopifyClient;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(
            ProductQuery query,
            CancellationToken cancellationToken = default)
        {
            var parameters = query.ToKeyValuePair();

            throw new NotImplementedException();
        }
    }
}
