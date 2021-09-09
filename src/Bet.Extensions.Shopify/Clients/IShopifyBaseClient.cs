using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Models;

namespace Bet.Extensions.Shopify.Clients
{
    public interface IShopifyBaseClient
    {
        /// <summary>
        /// An instance of the <see cref="HttpClient"/> that has been configured to be used.
        /// </summary>
        HttpClient HttpClient { get; }

        /// <summary>
        /// Retrieves <typeparamref name="T"/> from Shopify with paging information.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri">The requested URI.</param>
        /// <param name="rootElement">The root elemet if present i.e 'prodducts'.</param>
        /// <param name="parameters">The optional parameters for the query.</param>
        /// <param name="cancellationToken">The Cancellation Token.</param>
        /// <returns>Returns paged result for the <typeparamref name="T"/>.</returns>
        Task<PagedResponse<T>> ListAsync<T>(
            string requestUri,
            string? rootElement = null,
            IList<KeyValuePair<string, object>>? parameters = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all of the <typeparamref name="T"/> without paging.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="rootElement"></param>
        /// <param name="parameters"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> ListAllAsync<T>(
            string requestUri,
            string? rootElement = null,
            IList<KeyValuePair<string, object>>? parameters = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Upsert the items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="parameters"></param>
        /// <param name="rootElement"></param>
        /// <param name="content"></param>
        /// <param name="httpMethod"></param>
        /// <param name="headers"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T?> ExecuteAsync<T>(
            string requestUri,
            IList<KeyValuePair<string, object>>? parameters = null,
            string? rootElement = null,
            HttpContent? content = null,
            HttpMethod? httpMethod = null,
            Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes record.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteAsync(string requestUri, CancellationToken cancellationToken);
    }
}
