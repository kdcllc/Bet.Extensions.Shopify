﻿using System;
using System.Net.Http;

using Bet.Extensions.Shopify;
using Bet.Extensions.Shopify.Abstractions.Options;
using Bet.Extensions.Shopify.Clients;
using Bet.Extensions.Shopify.Clients.Impl;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Polly;
using Polly.Extensions.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ShopifyServiceExtensions
    {
        /// <summary>
        /// Adds Shopify <see cref="HttpClient"/> with retries and leaky bucket support.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddShopifyClient(
            this IServiceCollection services,
            Action<ShopifyOptions>? configOptions = null)
        {
            // configure shopify options
            services.AddChangeTokenOptions<ShopifyOptions>(nameof(ShopifyOptions), configureAction: (o) => configOptions?.Invoke(o));

            // register generic types for clients.
            services.AddTransient(typeof(IShopifyTypedClient<,,>), typeof(ShopifyTypedClient<,,>));

            services.AddHttpClient<IShopifyBaseClient, ShopifyClient>()
              .ConfigureHttpClient((sp, client) =>
              {
                  var options = sp.GetRequiredService<IOptions<ShopifyOptions>>().Value;

                  client.Timeout = options.Timeout;
                  client.BaseAddress = options.ShopAdminWithVersionUri;

                  client.DefaultRequestHeaders.Add("X-Shopify-Access-Token", $"{options.ShopAccessToken}");
              })

              // transient error retry 5 times.
              .AddPolicyHandler(Policy.Handle<HttpRequestException>().OrTransientHttpStatusCode().RetryAsync(5))
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
