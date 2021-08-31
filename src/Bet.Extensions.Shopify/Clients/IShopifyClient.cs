using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Models;

namespace Bet.Extensions.Shopify.Clients
{
    public interface IShopifyClient
    {
        /// <summary>
        /// Retrieves <typeparamref name="T"/> from Shopify with paging information.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri">The requested URI.</param>
        /// <param name="rootElement">The root elemet if present i.e 'prodducts'.</param>
        /// <param name="parameters">The optional parameters for the query.</param>
        /// <param name="cancellationToken">The Cancellation Token.</param>
        /// <returns>Returns paged result for the <typeparamref name="T"/>.</returns>
        Task<PagedResponse<T>> GetAsync<T>(
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
        Task<IEnumerable<T>> GetAllAsync<T>(
            string requestUri,
            string? rootElement = null,
            IList<KeyValuePair<string, object>>? parameters = null,
            CancellationToken cancellationToken = default);
    }
}
