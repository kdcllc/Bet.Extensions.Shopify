using System.Text.Json;

using Bet.AspNetCore.Shopify.Middleware.Webhooks;
using Bet.Extensions.Shopify.Models;
using Bet.Extensions.Shopify.Models.Products;

namespace ShopifyWeb.Events;

public class ProductWebhookHandler : IWebhookHandler<Product>
{
    private readonly ILogger<ProductWebhookHandler> _logger;

    public ProductWebhookHandler(ILogger<ProductWebhookHandler> logger)
    {
        _logger = logger;
    }

    public Task<WebHookResult> HandleEventAsync(Product @event, string topicName, CancellationToken cancellationToken = default)
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
