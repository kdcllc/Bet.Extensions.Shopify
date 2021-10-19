using System;
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
            Action<ShopifyOptions, IServiceProvider>? configOptions = null)
        {
            // configure shopify options
            services.AddChangeTokenOptions<ShopifyOptions>(nameof(ShopifyOptions), configureAction: (o, sp) => configOptions?.Invoke(o, sp));

            // register generic types for clients.
            services.AddTransient(typeof(IShopifyTypedClient<,,>), typeof(ShopifyTypedClient<,,>));

            services.AddHttpClient<IShopifyBaseClient, ShopifyBaseClient>()
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
                        var logger = loggerFactory.CreateLogger(request?.RequestUri?.ToString() ?? nameof(ShopifyBaseClient));

                        var transientPolicy = Policy.Handle<HttpRequestException>()
                                     .OrTransientHttpStatusCode()
                                     .RetryAsync(options.ResilienceOptions.RetryCount)
                                     .WithPolicyKey("ShopifyTransientHttpPolicy");

                        var leakyBucketPolicy = PolicyBucket.GetRetryPolicy(options.ResilienceOptions, logger).WithPolicyKey("ShopifyLeakyBuketPolicy");

                        return Policy.WrapAsync<HttpResponseMessage>(leakyBucketPolicy, transientPolicy).WithPolicyKey("ShopifyPolicy");
                    });

            return services;
        }
    }
}
