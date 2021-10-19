# Bet.AspNetCore.Shopify

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://raw.githubusercontent.com/kdcllc/Bet.AspNetCore.Shopify/master/LICENSE)
![Master CI](https://github.com/kdcllc/Bet.AspNetCore.Shopify/actions/workflows/master.yml/badge.svg)
![Dev CI](https://github.com/kdcllc/Bet.AspNetCore.Shopify/actions/workflows/dev.yml/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Bet.AspNetCore.Shopify.svg)](https://www.nuget.org/packages?q=BBet.AspNetCore.Shopify)
![Nuget](https://img.shields.io/nuget/dt/Bet.AspNetCore.Shopify)
[![feedz.io](https://img.shields.io/badge/endpoint.svg?url=https://f.feedz.io/kdcllc/bet-extensions-shopify/shield/Bet.AspNetCore.Shopify/latest)](https://f.feedz.io/kdcllc/bet-extensions-shopify/packages/Bet.AspNetCore.Shopify/latest/download)

## Summary

The purpose of this repo is enable Shopify Admin API for usage with AspNetCore application that can be used by any project.

## Hire me

Please send [email](mailto:kingdavidconsulting@gmail.com) if you consider to **hire me**.

[![buymeacoffee](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/vyve0og)

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Install

```csharp
    dotnet add package Bet.AspNetCore.Shopify
```

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
