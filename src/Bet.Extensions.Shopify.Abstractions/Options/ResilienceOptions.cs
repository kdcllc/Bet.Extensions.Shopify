using System;

namespace Bet.Extensions.Shopify.Abstractions.Options
{
    public class ResilienceOptions
    {
        public int RetryCount { get; set; } = 4;

        public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(5);
    }
}
