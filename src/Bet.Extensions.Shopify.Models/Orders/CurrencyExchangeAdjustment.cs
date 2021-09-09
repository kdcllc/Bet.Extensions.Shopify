using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Orders
{
    /// <summary>
    /// An adjustment on the transaction showing the amount lost or gained due to fluctuations in the currency exchange rate.
    /// </summary>
    /// <remarks>
    /// Requires the header X-Shopify-Api-Features = include-currency-exchange-adjustments.
    /// </remarks>
    public class CurrencyExchangeAdjustment : BaseModel
    {
        /// <summary>
        /// The difference between the amounts on the associated transaction and the parent transaction.
        /// </summary>
        [JsonPropertyName("adjustment")]
        public decimal? Adjustment { get; set; }

        /// <summary>
        /// The amount of the parent transaction in the shop currency.
        /// </summary>
        [JsonPropertyName("original_amount")]
        public decimal? OriginalAmount { get; set; }

        /// <summary>
        /// The amount of the associated transaction in the shop currency.
        /// </summary>
        [JsonPropertyName("final_amount")]
        public decimal? FinalAmount { get; set; }

        /// <summary>
        /// The shop currency.
        /// </summary>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }
    }
}
