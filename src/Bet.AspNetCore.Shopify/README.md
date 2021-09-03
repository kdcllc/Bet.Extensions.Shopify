# Bet.AspNetCore.Shopify

## Webooks

To add Shopify Webhooks to the existing AspNetCore is very simple.

```csharp

    // configure webhooks
    builder.Services.AddShopifyWebHooks()
        .AddWebhook<ProductCreateEventHandler, Product>("products/create");

    // add middleware
    app.UseShopifyWebhooks();
```

Create Event Handler as follows:

```csharp
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
                var json = JsonSerializer.Serialize(@event);
                _logger.LogInformation("Received: {json}", json);
                return Task.FromResult(new WebHookResult());
            }
            catch (Exception ex)
            {
                return Task.FromResult(new WebHookResult(ex));
            }
        }
    }
```

## HMAC Validation for webhooks

[Verify the request is from Shopify](https://shopify.dev/apps/webhooks#verify-the-request-is-from-shopify)
[Verify a webhook](https://shopify.dev/apps/webhooks/configuring#verify-a-webhook)

## OAuth2 Authentication Flow

This handler supports OAuth2 authentication mechanism.

[Shopify Official Documentation](https://shopify.dev/apps/auth/oauth)
![Shopify OAuth Flow](../../img/oauth-shopify-flow.png)

## Resources

[AspNet.Security.OAuth.Providers](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers)
