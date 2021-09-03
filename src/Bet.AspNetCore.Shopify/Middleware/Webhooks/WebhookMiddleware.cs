using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Bet.AspNetCore.Shopify.Middleware.Webhooks.Options;
using Bet.Extensions.Shopify;
using Bet.Extensions.Shopify.Abstractions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bet.AspNetCore.Shopify.Middleware.Webhooks
{
    internal class WebhookMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;
        private readonly IWebHostEnvironment _enviroment;
        private readonly ILogger<WebhookMiddleware> _logger;
        private readonly WebhooksOptions _options;

        public WebhookMiddleware(
            RequestDelegate next,
            IServiceProvider serviceProvider,
            IWebHostEnvironment enviroment,
            IOptions<WebhooksOptions> options,
            ILogger<WebhookMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _enviroment = enviroment ?? throw new ArgumentNullException(nameof(enviroment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            // check for the route and method.
            if (context.Request.Path != _options.HttpRoute
                || context.Request.Method != _options.HttpMethod)
            {
                await _next(context);
                return;
            }

            var cts = CancellationTokenSource.CreateLinkedTokenSource(context.RequestAborted);

            var response = context.Response;

            try
            {
                if (context.Request.Headers.TryGetValue(ShopifyHeaders.WebhookTopic, out var topicName))
                {
                    var webhook = _options.WebHooksRegistrations.FirstOrDefault(x => string.Equals(x.TopicName, topicName, StringComparison.InvariantCultureIgnoreCase));

                    // found our match.
                    if (webhook != null)
                    {
                        _logger.LogInformation("Registration for Shopify Topic: {topicName} was received.", topicName);

                        var result = await ProcessEventAsync(context, webhook, cts.Token);

                        if (result?.Exception != null
                            && !_enviroment.IsDevelopment()
                            && !_options.ThrowIfException)
                        {
                            response.ContentType = "application/json";
                            response.StatusCode = StatusCodes.Status500InternalServerError;
                            await response.WriteAsync(string.Empty);
                        }
                        else if (_options.ThrowIfException
                                && result?.Exception != null)
                        {
                            throw new AggregateException($"{nameof(WebhookMiddleware)} raised exceptions.", result.Exception);
                        }
                    }
                    else
                    {
                        _logger.LogWarning("Registration for Shopify Topic: {topicName} wasn't found.", topicName);
                    }
                }
            }
            finally
            {
                cts?.Dispose();
            }

            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status200OK;
            await response.WriteAsync(string.Empty);
        }

        private async Task<WebHookResult> ProcessEventAsync(HttpContext context, WebhookRegistration webhook, CancellationToken cancellationToken)
        {
            try
            {
                if (!context.Request.HasJsonContentType())
                {
                    throw new BadHttpRequestException(
                        "Request content type was not a recognized JSON content type.",
                        StatusCodes.Status415UnsupportedMediaType);
                }

                var json = await context.Request.ReadFromJsonAsync(webhook.EventType, SystemTextJson.Options, cancellationToken);

                using var scope = _serviceProvider.CreateScope();
                var service = webhook.HandlerFactory(scope.ServiceProvider);

                var method = webhook.HandlerType.GetMethod("HandleEventAsync");

                return await (Task<WebHookResult>)method.Invoke(service, parameters: new object[] { json, cancellationToken });
            }
            catch (Exception ex)
            {
                return new WebHookResult(ex);
            }
        }
    }
}
