using System;

using Bet.AspNetCore.Shopify.Middleware.Hmac;
using Bet.AspNetCore.Shopify.Middleware.Hmac.Options;
using Bet.AspNetCore.Shopify.Services;
using Bet.AspNetCore.Shopify.Services.Impl;

using Microsoft.AspNetCore.Mvc;

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
    }
}
