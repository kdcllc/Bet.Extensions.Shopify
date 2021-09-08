using System.Text.Json.Serialization;

namespace Bet.Extensions.Shopify.Models
{
    /// <summary>
    /// An object containing information about the payment.
    /// </summary>
    public class PaymentDetails
    {
        /// <summary>
        /// The response code from the address verification system (AVS).
        /// The code is a single letter. See this chart for the codes and their definitions.
        /// </summary>
        [JsonPropertyName("avs_result_code")]
        public string? AvsResultCode { get; set; }

        /// <summary>
        /// The issuer identification number (IIN), formerly known as the bank identification number (BIN), of the customer's credit card.
        /// This is made up of the first few digits of the credit card number.
        /// </summary>
        [JsonPropertyName("credit_card_bin")]
        public string? CreditCardBin { get; set; }

        /// <summary>
        /// The response code from the credit card company indicating whether the customer entered the card security code (card verification value) correctly.
        /// The code is a single letter or empty string. See this chart for the codes and their definitions.
        /// </summary>
        [JsonPropertyName("cvv_result_code")]
        public string? CvvResultCode { get; set; }

        /// <summary>
        /// The customer's credit card number, with most of the leading digits redacted.
        /// </summary>
        [JsonPropertyName("credit_card_number")]
        public string CreditCardNumber { get; set; }

        /// <summary>
        /// The name of the company who issued the customer's credit card.
        /// </summary>
        [JsonPropertyName("credit_card_company")]
        public string? CreditCardCompany { get; set; }
    }
}
