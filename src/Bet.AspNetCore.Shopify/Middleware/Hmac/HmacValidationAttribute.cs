using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

using Bet.AspNetCore.Shopify.Services;
using Bet.Extensions.Shopify.Abstractions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bet.AspNetCore.Shopify.Middleware.Hmac
{
    public class HmacValidationAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.RequestServices.GetService(typeof(IHmacValidator)) is IHmacValidator validator)
            {
                var valid = await validator.ValidateAsync(context.HttpContext.Request);
                if (!valid)
                {
                    // Request did not pass validation. Return a JSON error message
                    context.HttpContext.Response.ContentType = "application/json";

                    var headers = context.HttpContext.Request.Headers;

                    headers.TryGetValue(ShopifyHeaders.WebhookTopic, out var topic);
                    headers.TryGetValue(ShopifyHeaders.ShopDomain, out var domain);
                    headers.TryGetValue(ShopifyHeaders.HmacSha256, out var hmacValue);

                    var details = $"Validation failed for domain: {domain} with topic {topic} {hmacValue}";

                    var result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.Unauthorized,
                        Title = "Webhook did not pass validation result.",
                        Detail = details
                    };

                    var body = JsonSerializer.SerializeToUtf8Bytes(result);

                    using var buffer = new MemoryStream(body);
                    context.HttpContext.Response.StatusCode = 401;
                    await buffer.CopyToAsync(context.HttpContext.Response.Body);
                }
                else
                {
                    await next();
                }
            }
        }
    }
}
