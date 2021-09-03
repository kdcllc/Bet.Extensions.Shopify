using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Models;
using Bet.Extensions.Shopify.Models.Queries;

namespace Bet.Extensions.Shopify.Clients.Impl
{
    public class ShopifyTypedClient<TData, TQuery, TCountQuery> : IShopifyTypedClient<TData, TQuery, TCountQuery>
        where TData : class
        where TQuery : class
        where TCountQuery : class
    {
        private readonly IShopifyBaseClient _shopifyClient;

        public ShopifyTypedClient(IShopifyBaseClient shopifyClient)
        {
            _shopifyClient = shopifyClient ?? throw new ArgumentNullException(nameof(shopifyClient));
        }

        public async Task<int> CountAsync(
            string requestUri,
            string? rootElement = null,
            TCountQuery? query = null,
            CancellationToken cancellationToken = default)
        {
            var parameters = query?.ToKeyValuePair();
            var result = await _shopifyClient.ListAsync<int>(requestUri, rootElement, parameters, cancellationToken);

            return result.Payload;
        }

        public async Task<TData?> CreateAsync(
            string requestUri,
            object data,
            string? rootElement = null,
            CancellationToken cancellationToken = default)
        {
            var content = new JsonContent(data);

            return await _shopifyClient.ExecuteAsync<TData>(
                requestUri,
                rootElement: rootElement,
                content: content,
                httpMethod: HttpMethod.Post,
                cancellationToken: cancellationToken);
        }

        public Task DeleteAsync(
            string requestUri,
            CancellationToken cancellationToken = default)
        {
            return _shopifyClient.DeleteAsync(requestUri, cancellationToken);
        }

        public async Task<TData?> GetAsync(
            string requestUri,
            FieldsQuery? query = null,
            string? rootElement = null,
            CancellationToken cancellationToken = default)
        {
            var parameters = query?.ToKeyValuePair();

            return await _shopifyClient.ExecuteAsync<TData>(
                requestUri,
                parameters,
                rootElement: rootElement,
                cancellationToken: cancellationToken);
        }

        public async Task<IEnumerable<TData>> ListAllAsync(
            string requestUri,
            string? rootElement = null,
            TQuery? query = null,
            CancellationToken cancellationToken = default)
        {
            var parameters = query?.ToKeyValuePair();
            return await _shopifyClient.ListAllAsync<TData>(
                requestUri,
                rootElement,
                parameters,
                cancellationToken);
        }

        public async Task<PagedResponse<IEnumerable<TData>>> ListAsync(
            string requestUri,
            string? rootElement = null,
            TQuery? query = null,
            CancellationToken cancellationToken = default)
        {
            var parameters = query?.ToKeyValuePair();
            return await _shopifyClient.ListAsync<IEnumerable<TData>>(
                requestUri,
                rootElement,
                parameters,
                cancellationToken);
        }

        public async Task<TData?> UpdateAsync(
            string requestUri,
            object data,
            string? rootElement = null,
            CancellationToken cancellationToken = default)
        {
            var content = new JsonContent(data);

            return await _shopifyClient.ExecuteAsync<TData>(
                requestUri,
                rootElement: rootElement,
                content: content,
                httpMethod: HttpMethod.Put,
                cancellationToken: cancellationToken);
        }
    }
}
