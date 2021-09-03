using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace Bet.AspNetCore.Shopify.Services
{
    public interface IHmacValidator
    {
        /// <summary>
        /// Validates <see cref="HttpRequest"/> if it contains Shopify HMAC header.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> ValidateAsync(HttpRequest request);
    }
}
