using System;

using Bet.AspNetCore.Shopify.Middleware.Hmac;
using Bet.AspNetCore.Shopify.Middleware.Hmac.Options;
using Bet.AspNetCore.Shopify.Middleware.Webhooks;
using Bet.AspNetCore.Shopify.Middleware.Webhooks.Options;
using Bet.AspNetCore.Shopify.Services;
using Bet.AspNetCore.Shopify.Services.Impl;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ShopifyAspNetCoreServiceCollection
    {
        /// <summary>
        /// Registers Shopify Hmac webhook validation.
        /// <see href="https://shopify.dev/apps/webhooks/configuring#verify-a-webhook"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configure"></param>
        /// <returns></returns>
        public static IServiceCollection AddShopifyHmacValidator(
            this IServiceCollection services,
            Action<HmacValidationOptions, IServiceProvider>? configure = default)
        {
            services.AddChangeTokenOptions<HmacValidationOptions>(
                nameof(HmacValidationOptions),
                configureAction: (o, sp) =>
                {
                    configure?.Invoke(o, sp);
                });

            // validator service
            services.AddTransient<IHmacValidator, HmacValidator>();

            services.AddScoped<HmacValidationAttribute>();

            return services;
        }

        /// <summary>
        /// Adds Shopify Webhooks middlware configurations.
        /// </summary>
        /// <param name="services">The DI services.</param>
        /// <param name="route">The Http route for the webhooks to be processed. The default is '/webhooks'.</param>
        /// <param name="method">The http method. The default is 'POST'.</param>
        /// <param name="throwIfException">The flag to throw or not the exceptions.</param>
        /// <returns></returns>
        public static IWebhookBuilder AddShopifyWebHooks(
            this IServiceCollection services,
            string route = "/webhooks",
            string method = "POST",
            bool throwIfException = true)
        {
            var builder = new WebhookBuilder(services);

            builder.Services.Configure<WebhooksOptions>(options =>
            {
                options.HttpRoute = route;
                options.HttpMethod = method;
                options.ThrowIfException = throwIfException;
            });

            return builder;
        }
    }
}
