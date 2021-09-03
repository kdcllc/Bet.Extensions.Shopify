using Microsoft.Extensions.DependencyInjection;

namespace Bet.AspNetCore.Shopify.Middleware.Webhooks
{
    public interface IWebhookBuilder
    {
        /// <summary>
        /// Dependecy Injection Container.
        /// </summary>
        IServiceCollection Services { get; }

        /// <summary>
        /// Add Shopifu Webhook Event Handler.
        /// </summary>
        /// <typeparam name="THandler">The webhook handler.</typeparam>
        /// <typeparam name="TEvent">The webhook event type.</typeparam>
        /// <param name="topicName">The topic name for shopify webhook event i.e 'order/create'.
        /// <see href="https://shopify.dev/api/admin/rest/reference/events/webhook#considerations-2021-07"/>.</param>
        /// <returns></returns>
        IWebhookBuilder AddWebhook<THandler, TEvent>(string topicName)
            where TEvent : class
            where THandler : class, IWebhookHandler<TEvent>;
    }
}
