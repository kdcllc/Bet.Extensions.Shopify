using System;

namespace Bet.AspNetCore.Shopify.Middleware.Webhooks
{
    internal class WebhookRegistration
    {
        private Func<IServiceProvider, object>? _handlerFactory;

        public WebhookRegistration(
            string topicName,
            Func<IServiceProvider, object> factory,
            Type handlerType,
            Type eventType)
        {
            TopicName = topicName;
            HandlerFactory = factory ?? throw new ArgumentNullException(nameof(factory));
            HandlerType = handlerType ?? throw new ArgumentNullException(nameof(handlerType));
            EventType = eventType ?? throw new ArgumentNullException(nameof(eventType));
        }

        public string TopicName { get; }

        public Type HandlerType { get; }

        public Type EventType { get; }

        public Func<IServiceProvider, object>? HandlerFactory
        {
            get => _handlerFactory;
            set => _handlerFactory = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
