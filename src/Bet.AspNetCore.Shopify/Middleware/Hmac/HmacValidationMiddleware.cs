using System.Threading.Tasks;

using Bet.AspNetCore.Shopify.Middleware.Hmac.Options;
using Bet.AspNetCore.Shopify.Services;
using Bet.Extensions.Shopify.Abstractions;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Bet.AspNetCore.Shopify.Middleware.Hmac
{
    internal class HmacValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHmacValidator _validator;
        private readonly HmacValidationOptions _options;

        public HmacValidationMiddleware(
            RequestDelegate next,
            IHmacValidator validator,
            IOptions<HmacValidationOptions> options)
        {
            _next = next ?? throw new System.ArgumentNullException(nameof(next));
            _validator = validator ?? throw new System.ArgumentNullException(nameof(validator));
            _options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var url = context.Request.Path.Value;
            foreach (var item in _options.WebHookPaths)
            {
                if (string.Equals(url, item, System.StringComparison.InvariantCultureIgnoreCase)
                    && _options.IsEnabled)
                {
                    var valid = await _validator.ValidateAsync(context.Request);

                    if (!valid)
                    {
                        var headers = context.Request.Headers;

                        headers.TryGetValue(ShopifyHeaders.WebhookTopic, out var topic);
                        headers.TryGetValue(ShopifyHeaders.ShopDomain, out var domain);
                        headers.TryGetValue(ShopifyHeaders.HmacSha256, out var hmacValue);

                        var details = $"Invalid Request HMAC value doesn't match. Shopify Domain: {domain} with topic {topic} and hmac value: {hmacValue}";

                        throw new HmacValidatorException(details);
                    }
                }
            }

            await _next(context);
        }
    }
}
