using System;

namespace Bet.Extensions.Shopify.Abstractions.Options
{
    public class ResilienceOptions
    {
        public int RetryCount { get; set; }

        public TimeSpan Delay { get; set; }
    }
}
