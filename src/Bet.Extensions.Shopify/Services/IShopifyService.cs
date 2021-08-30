using System.Threading;
using System.Threading.Tasks;

namespace Bet.Extensions.Shopify.Services
{
    public interface IShopifyService
    {
        Task<(T? result, string pageInfo)> GetTaskAsync<T>(string url, object? parameters, CancellationToken cancellationToken);
    }
}
