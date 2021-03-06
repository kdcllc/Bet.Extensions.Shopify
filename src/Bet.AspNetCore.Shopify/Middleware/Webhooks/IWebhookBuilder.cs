using Microsoft.Extensions.DependencyInjection;

namespace Bet.AspNetCore.Shopify.Middleware.Webhooks;

public interface IWebhookBuilder
{
    /// <summary>
    /// Dependency Injection Container.
    /// </summary>
    IServiceCollection Services { get; }

    /// <summary>
    /// Add Shopify Webhook Event Handler.
    /// </summary>
    /// <typeparam name="THandler">The webhook handler.</typeparam>
    /// <typeparam name="TEvent">The webhook event type.</typeparam>
    /// <param name="topicNames">The topic name for shopify webhook event i.e 'order/create'.
    /// <see href="https://shopify.dev/api/admin/rest/reference/events/webhook#considerations-2021-07"/>.</param>
    /// <returns></returns>
    IWebhookBuilder AddWebhook<THandler, TEvent>(params string[] topicNames)
        where THandler : class, IWebhookHandler<TEvent>
        where TEvent : class;
}
