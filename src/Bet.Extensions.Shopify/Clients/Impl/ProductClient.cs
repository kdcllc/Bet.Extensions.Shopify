using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Models;
using Bet.Extensions.Shopify.Models.Products;
using Bet.Extensions.Shopify.Queries;

namespace Bet.Extensions.Shopify.Clients.Impl
{
    public class ProductClient : IProductClient
    {
        private readonly IShopifyClient _shopifyClient;

        public ProductClient(IShopifyClient shopifyClient)
        {
            _shopifyClient = shopifyClient ?? throw new System.ArgumentNullException(nameof(shopifyClient));
        }

        public async Task<IEnumerable<Product>> ListAllAsync(
            ProductQuery? query = null,
            CancellationToken cancellationToken = default)
        {
            var parameters = query?.ToKeyValuePair();
            return await _shopifyClient.ListAllAsync<Product>("products.json", "products", parameters, cancellationToken);
        }

        public async Task<PagedResponse<IEnumerable<Product>>> ListAsync(
            ProductQuery? query = null,
            CancellationToken cancellationToken = default)
        {
            var parameters = query?.ToKeyValuePair();
            return await _shopifyClient.ListAsync<IEnumerable<Product>>("products.json", "products", parameters, cancellationToken);
        }

        public async Task<int> CountAsync(
            ProductCountQuery? query = null,
            CancellationToken cancellationToken = default)
        {
            var parameters = query?.ToKeyValuePair();
            var result = await _shopifyClient.ListAsync<int>("products/count.json", "count", parameters: parameters, cancellationToken: cancellationToken);

            return result.Payload;
        }

        public async Task<Product?> GetAsync(
            long productId,
            FieldsQuery? query = null,
            CancellationToken cancellationToken = default)
        {
            var parameters = query?.ToKeyValuePair();

            return await _shopifyClient.ExecuteAsync<Product>(
                $"products/{productId}.json",
                parameters,
                rootElement: "product",
                cancellationToken: cancellationToken);
        }

        public async Task<Product?> CreateAsync(
            Product product,
            CancellationToken cancellationToken = default)
        {
            var content = new JsonContent(new { product });

            return await _shopifyClient.ExecuteAsync<Product>(
                "products.json",
                rootElement: "product",
                content: content,
                httpMethod: HttpMethod.Post,
                cancellationToken: cancellationToken);
        }

        public async Task<Product?> UpdateAsync(
            Product product,
            CancellationToken cancellationToken = default)
        {
            var content = new JsonContent(new { product });

            return await _shopifyClient.ExecuteAsync<Product>(
                $"products/{product.Id}.json",
                rootElement: "product",
                content: content,
                httpMethod: HttpMethod.Put,
                cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(
            long productId,
            CancellationToken cancellationToken = default)
        {
            var requestUri = $"products/{productId}.json";
            await _shopifyClient.DeleteAsync(requestUri, cancellationToken);
        }
    }
}
