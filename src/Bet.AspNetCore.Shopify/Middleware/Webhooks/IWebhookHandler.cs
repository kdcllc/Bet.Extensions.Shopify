using System.Threading;
using System.Threading.Tasks;

namespace Bet.AspNetCore.Shopify.Middleware.Webhooks
{
    public interface IWebhookHandler<TEvent> where TEvent : class
    {
        /// <summary>
        /// A Handler for the Shopify event.
        /// </summary>
        /// <param name="event">The actual event.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<WebHookResult> HandleEventAsync(TEvent @event, CancellationToken cancellationToken = default);
    }
}
