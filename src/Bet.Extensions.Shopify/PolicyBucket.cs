using System.Net;

using Bet.Extensions.Shopify.Abstractions.Options;

using Microsoft.Extensions.Logging;

using Polly;

namespace Bet.Extensions.Shopify;

public static class PolicyBucket
{
    /// <summary>
    /// Simple Wait and Retry Resilience policy for Shopify Clients.
    /// </summary>
    /// <param name="options">The configuration for Reslience options.</param>
    /// <param name="logger">The logger for the retries.</param>
    public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(
        ResilienceOptions options,
        ILogger logger)
    {
        return Policy
            .Handle<HttpRequestException>()
            .OrResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.TooManyRequests ||
                                                r.StatusCode == HttpStatusCode.ServiceUnavailable)
            .WaitAndRetryAsync(
                options.RetryCount,
                sleepDurationProvider: (retryCount, response, _) =>
                {
                    var delay = options.Delay;

                    // if an exception was thrown, this will be null
                    if (response.Result != null)
                    {
                        // https://shopify.dev/api/usage/rate-limits#retry-after-header
                        if (!response.Result.Headers.TryGetValues("Retry-After", out var values))
                        {
                            if (int.TryParse(values?.FirstOrDefault(), out var delayInSeconds))
                            {
                                delay = TimeSpan.FromSeconds(delayInSeconds);
                            }
                        }
                    }
                    else
                    {
                        var exponentialBackoff = Math.Pow(2, retryCount);
                        var delayInSeconds = exponentialBackoff * options.Delay.Milliseconds;
                        delay = TimeSpan.FromMilliseconds(delayInSeconds);
                    }

                    logger.LogDebug("Retry count: {retryCount} with delay {delay}", retryCount, delay);

                    return delay;
                },
                onRetryAsync: async (response, timespan, retryCount, context) =>
                {
                    // add your logging and what you want to do
                    logger.LogError(response?.Exception, "Failed retrying {retryCount}", retryCount);
                    await Task.CompletedTask;
                });
    }
}
