using System.Text.Json;

using Bet.AspNetCore.Shopify.Middleware.Webhooks;
using Bet.Extensions.Shopify;
using Bet.Extensions.Shopify.Models.Orders;

namespace ShopifyWeb.Events.Products
{
    public class OrderWebhookHandler : IWebhookHandler<Order>
    {
        private readonly ILogger<OrderWebhookHandler> _logger;

        public OrderWebhookHandler(ILogger<OrderWebhookHandler> logger)
        {
            _logger = logger;
        }

        public Task<WebHookResult> HandleEventAsync(Order @event, string topicName, CancellationToken cancellationToken = default)
        {
            try
            {
                var json = JsonSerializer.Serialize(@event, SystemTextJson.Options);
                _logger.LogInformation("Received topic {topicName}: {json}", topicName, json);
                return Task.FromResult(new WebHookResult());
            }
            catch (Exception ex)
            {
                return Task.FromResult(new WebHookResult(ex));
            }
        }
    }
}
