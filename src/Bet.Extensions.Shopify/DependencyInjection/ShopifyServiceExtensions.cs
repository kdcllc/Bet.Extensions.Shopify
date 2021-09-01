using System;

using Bet.Extensions.Shopify;
using Bet.Extensions.Shopify.Abstractions.Options;
using Bet.Extensions.Shopify.Clients;
using Bet.Extensions.Shopify.Clients.Impl;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ShopifyServiceExtensions
    {
        public static IServiceCollection AddShopify(
            this IServiceCollection services,
            Action<ShopifyOptions>? configOptions = null)
        {
            // configure shopify options
            services.AddChangeTokenOptions<ShopifyOptions>(nameof(ShopifyOptions), configureAction: (o) => configOptions?.Invoke(o));

            services.AddTransient<IInventoryClient, InventoryClient>();
            services.AddTransient<IProductClient, ProductClient>();

            services.AddHttpClient<IShopifyClient, ShopifyClient>()
              .ConfigureHttpClient((sp, client) =>
              {
                  var options = sp.GetRequiredService<IOptions<ShopifyOptions>>().Value;

                  client.Timeout = options.Timeout;
                  client.BaseAddress = options.ShopAdminWithVersionUri;

                  client.DefaultRequestHeaders.Add("X-Shopify-Access-Token", $"{options.ShopAccessToken}");
              })
              .AddPolicyHandler((sp, request) =>
              {
                  var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
                  var options = sp.GetRequiredService<IOptions<ShopifyOptions>>().Value;
                  var logger = loggerFactory.CreateLogger(request?.RequestUri?.ToString() ?? nameof(ShopifyClient));

                  return PolicyBucket.GetRetryPolicy(options.ResilienceOptions, logger);
              });

            return services;
        }
    }
}
