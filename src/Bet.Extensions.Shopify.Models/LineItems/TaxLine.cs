namespace Bet.Extensions.Shopify.Models.LineItems;

public class TaxLine
{
    /// <summary>
    /// The amount of tax to be charged.
    /// </summary>
    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    /// <summary>
    /// The rate of tax to be applied.
    /// </summary>
    [JsonPropertyName("rate")]
    public decimal? Rate { get; set; }

    /// <summary>
    /// The name of the tax.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// The amount added to the order for this tax in shop and presentment currencies.
    /// </summary>
    [JsonPropertyName("price_set")]
    public MoneyBag? PriceSet { get; set; }

    /// <summary>
    /// <para>This field indicates whether the sales channel that submitted the order is liable for remittance for each tax line. </para>
    /// <para>It can contain the following values: </para>
    /// <para>- true indicates that the channel is responsible for remittance of the tax line. </para>
    /// <para>- false indicates that the channel is not responsible for remittance of the tax line. </para>
    /// <para>- null indicates that it is unknown who has the responsibility, and that the merchant should check with a local tax authority to determine their tax obligations.</para>
    /// <para><see href="https://shopify.dev/changelog/taxline-object-now-has-a-channel_liable-field"/>.</para>
    /// </summary>
    [JsonPropertyName("channel_liable")]
    public bool? ChannelLiable { get; set; }
}
