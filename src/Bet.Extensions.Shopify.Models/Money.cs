namespace Bet.Extensions.Shopify.Models;

/// <summary>
/// <para>A monetary value with currency.</para>
/// <para>To format currencies, combine this type's amount and currencyCode fields with your client's locale.</para>
/// <para><see href="https://shopify.dev/api/admin/graphql/reference/common-objects/moneyv2"/>.</para>
/// </summary>
public class Money
{
    /// <summary>
    /// The amount in the currency.
    /// </summary>
    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }

    /// <summary>
    /// The three-letter code (ISO 4217 format) for currency.
    /// </summary>
    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }
}
