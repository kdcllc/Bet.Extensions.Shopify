using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Bet.Extensions.Shopify.Abstractions.Options;

using Microsoft.Extensions.Logging;

using Polly;
using Polly.Extensions.Http;

namespace Bet.Extensions.Shopify
{
    public class PolicyBucket
    {
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
                    sleepDurationProvider: (retryCount, response, context) =>
                    {
                        var delay = options.Delay;

                        // if an exception was thrown, this will be null
                        if (response.Result != null)
                        {
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
}
