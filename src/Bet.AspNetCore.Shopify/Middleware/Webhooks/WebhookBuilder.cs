using System;

using Bet.AspNetCore.Shopify.Middleware.Webhooks.Options;

using Microsoft.Extensions.DependencyInjection;

namespace Bet.AspNetCore.Shopify.Middleware.Webhooks
{
    public class WebhookBuilder : IWebhookBuilder
    {
        public WebhookBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public IServiceCollection Services { get; }

        /// <summary>
        /// Add Shopify Webhook to the registration.
        /// </summary>
        /// <typeparam name="THandler">The type of webhook handler.</typeparam>
        /// <typeparam name="TEvent">The type of the webhook event.</typeparam>
        /// <param name="topicNames">The name of the topic i.e 'checkouts/delete'.</param>
        /// <returns></returns>
        public IWebhookBuilder AddWebhook<THandler, TEvent>(params string[] topicNames)
           where TEvent : class
           where THandler : class, IWebhookHandler<TEvent>
        {
            Services.Configure<WebhooksOptions>(options =>
            {
                options.WebHooksRegistrations.Add(new WebhookRegistration(
                    topicNames,
                    sp => ActivatorUtilities.GetServiceOrCreateInstance<THandler>(sp),
                    typeof(THandler),
                    typeof(TEvent)));
            });

            return this;
        }
    }
}
