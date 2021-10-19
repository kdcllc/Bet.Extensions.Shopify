namespace Bet.Extensions.Shopify.Models;

/// <summary>
/// <para>A collection of monetary values in their respective currencies.</para>
/// <para><seealso href="https://shopify.dev/api/admin/graphql/reference/common-objects/moneybag"/>.</para>
/// </summary>
public class MoneyBag
{
    /// <summary>
    /// Amount in shop currency.
    /// </summary>
    [JsonPropertyName("shop_money")]
    public Money? ShopMoney { get; set; }

    /// <summary>
    /// Amount in presentment currency.
    /// </summary>
    [JsonPropertyName("presentment_money")]
    public Money? PresentmentMoney { get; set; }
}
