using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Models.Inventory;

namespace Bet.Extensions.Shopify.Clients
{
    public interface IInventoryClient
    {
        /// <summary>
        /// Retrieves a list of locations.
        /// <seealso cref="!:https://shopify.dev/api/admin/rest/reference/inventory/location#what-you-can-do-with-location-2021-07"/>.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<Location>?> GetLocationsAsync(CancellationToken cancellationToken = default);
    }
}
