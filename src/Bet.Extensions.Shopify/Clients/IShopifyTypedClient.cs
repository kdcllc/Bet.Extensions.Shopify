using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Models;
using Bet.Extensions.Shopify.Models.Queries;

namespace Bet.Extensions.Shopify.Clients
{
    /// <summary>
    /// The Shopify Admin API the resources.
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TCountQuery"></typeparam>
    public interface IShopifyTypedClient<TData, TQuery, TCountQuery>
        where TData : class
        where TQuery : class
        where TCountQuery : class
    {
        /// <summary>
        /// Query the resource query parameters and returns result.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="rootElement"></param>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CountAsync(
            string requestUri,
            string? rootElement = null,
            TCountQuery? query = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Query the resource for values.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="rootElement"></param>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<TData>> ListAllAsync(
            string requestUri,
            string? rootElement = null,
            TQuery? query = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Query the resource and return paged info details.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="rootElement"></param>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PagedResponse<IEnumerable<TData>>> ListAsync(
            string requestUri,
            string? rootElement = null,
            TQuery? query = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the single value for the resource.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="query"></param>
        /// <param name="rootElement"></param>
        /// <param name="headers"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TData?> GetAsync(
            string requestUri,
            TQuery? query = null,
            string? rootElement = null,
            Dictionary<string, string>? headers = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a resource.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="data"></param>
        /// <param name="rootElement"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TData?> CreateAsync(
            string requestUri,
            object data,
            string? rootElement = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Update a resource.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="data"></param>
        /// <param name="rootElement"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TData?> UpdateAsync(
            string requestUri,
            object data,
            string? rootElement = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a resource.
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteAsync(string requestUri, CancellationToken cancellationToken = default);
    }
}
