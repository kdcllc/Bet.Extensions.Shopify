using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Models;
using Bet.Extensions.Shopify.Models.Products;
using Bet.Extensions.Shopify.Queries;

namespace Bet.Extensions.Shopify.Clients
{
    /// <summary>
    /// The Shopify API the Product resource.
    /// <see href="https://shopify.dev/api/admin/rest/reference/products/product#what-you-can-do-with-product-2021-07"/>.
    /// </summary>
    public interface IProductClient
    {
        /// <summary>
        /// Retrieve a count of products.
        /// <code>
        ///     GET /admin/api/2021-07/products/count.json
        /// </code>
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CountAsync(ProductCountQuery? query = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve a list of all products without paging based on the <see cref="ProductQuery"/> parameters.
        /// <code>
        ///     GET /admin/api/2021-07/products.json
        /// </code>
        /// </summary>
        /// <param name="query">Query parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<Product>> ListAllAsync(ProductQuery? query = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieve a list of products based on the <see cref="ProductQuery"/> parameters.
        /// Seperate code must be employed to get thru paging.
        /// Default limit = 50 items.
        /// <code>
        ///     GET /admin/api/2021-07/products.json
        /// </code>        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PagedResponse<IEnumerable<Product>>> ListAsync(ProductQuery? query = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a single <see cref="Product"/>.
        /// <code>
        ///     GET /admin/api/2021-07/products/{product_id}.json
        /// </code>
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Product?> GetAsync(long productId, FieldsQuery? query = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a single <see cref="Product"/>.
        /// <code>
        ///     POST /admin/api/2021-07/products.json
        /// </code>
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Product?> CreateAsync(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a single <see cref="Product"/>.
        /// <code>
        ///    PUT /admin/api/2021-07/products/{product_id}.json
        /// </code>
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Product?> UpdateAsync(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a single <see cref="Product"/>.
        /// <code>
        ///     DELETE /admin/api/2021-07/products/{product_id}.json
        /// </code>
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteAsync(long productId, CancellationToken cancellationToken = default);
    }
}
