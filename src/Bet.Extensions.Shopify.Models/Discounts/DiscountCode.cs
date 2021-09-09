using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models.Discounts
{
    public class DiscountCode : BaseModel
    {
        /// <summary>
        /// The amount of the discount.
        /// </summary>
        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        /// <summary>
        /// The discount code.
        /// </summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        /// <summary>
        /// The type of discount. Known values are 'percentage', 'shipping', 'fixed_amount' and 'none'.
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
