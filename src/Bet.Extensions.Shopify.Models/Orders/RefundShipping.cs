using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Orders
{
    public class RefundShipping
    {
        /// <summary>
        /// Whether to refund all remaining shipping.
        /// </summary>
        [JsonPropertyName("full_refund")]
        public bool? FullRefund { get; set; }

        /// <summary>
        /// Set a specific amount to refund for shipping. Takes precedence over full_refund.
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// The maximum amount that can be refunded.
        /// </summary>
        [JsonPropertyName("maximum_refundable")]
        public decimal? MaximumRefundable { get; set; }
    }
}
