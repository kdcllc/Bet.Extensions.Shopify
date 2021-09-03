using System.Text.Json;

using Bet.AspNetCore.Shopify.Middleware.Webhooks;
using Bet.Extensions.Shopify;
using Bet.Extensions.Shopify.Models.Products;

namespace ShopifyWeb.Events.Products
{
    public class ProductCreateEventHandler : IWebhookHandler<Product>
    {
        private readonly ILogger<ProductCreateEventHandler> _logger;

        public ProductCreateEventHandler(ILogger<ProductCreateEventHandler> logger)
        {
            _logger = logger;
        }

        public Task<WebHookResult> HandleEventAsync(Product @event, CancellationToken cancellationToken = default)
        {
            try
            {
                var json = JsonSerializer.Serialize(@event, SystemTextJson.Options);
                _logger.LogInformation("Received: {json}", json);
                return Task.FromResult(new WebHookResult());
            }
            catch (Exception ex)
            {
                return Task.FromResult(new WebHookResult(ex));
            }
        }
    }
}
