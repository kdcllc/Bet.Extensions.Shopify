namespace Bet.Extensions.Shopify.Abstractions.Options;

public class ResilienceOptions
{
    /// <summary>
    /// Retry Shopify Admin Api submission. The Default value is 4 times.
    /// </summary>
    public int RetryCount { get; set; } = 4;

    /// <summary>
    /// The time delay between Shopify Admin Api Retries. The default is 5 seconds.
    /// </summary>
    public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(5);
}
