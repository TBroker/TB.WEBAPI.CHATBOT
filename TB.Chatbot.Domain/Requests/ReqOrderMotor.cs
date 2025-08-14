using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TB.Chatbot.Domain.Reponses;

namespace TB.Chatbot.Domain.Requests
{
    public class ReqOrderMotor
    {
        [Required]
        [JsonPropertyName("user_id")]
        public string? UserId { get; set; }

        [Required]
        [JsonPropertyName("quo_number")]
        public string? QuoteNumber { get; set; }

        [Required]
        [JsonPropertyName("car_brand")]
        public string? CarBrand { get; set; }

        [Required]
        [JsonPropertyName("car_model")]
        public string? CarModel { get; set; }

        [JsonPropertyName("car_sub_model")]
        public string? CarSubModel { get; set; }

        [Required]
        [JsonPropertyName("car_engine_size")]
        public string? CarEngineSize { get; set; }

        [Required]
        [JsonPropertyName("car_year")]
        public string? CarYear { get; set; }

        [Required]
        [JsonPropertyName("coverage_code")]
        public string? CoverageCode { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string? CustName { get; set; }

        [Required]
        [JsonPropertyName("last_name")]
        public string? CustLastName { get; set; }

        [JsonPropertyName("vehicle_license")]
        public string? VehicleLicense { get; set; }

        [JsonPropertyName("phone_number")]
        [RegularExpression(@"^\d+$", ErrorMessage = "The phone number must contain only digits.")]
        public string? PhoneNumber { get; set; }

        [JsonPropertyName("email")]
        [EmailAddress(ErrorMessage = "The email address is not in a valid format.")]
        public string? Email { get; set; }

        [Required]
        [JsonPropertyName("buy_cmi")]
        [RegularExpression("^(Y|N)$", ErrorMessage = "The value must be either 'Y' or 'N'.")]
        public string? BuyCMI { get; set; }

        [Required]
        [JsonPropertyName("premium_lists")]
        public List<PremiumList> PremiumList { get; set; } = default!;
    }

    public class PremiumList
    {
        [Required]
        [JsonPropertyName("premiums_id")]
        public decimal PremiumsId { get; set; }

        [Required]
        [JsonPropertyName("product_code")]
        public string? ProductCode { get; set; }

        [Required]
        [JsonPropertyName("commissions")]
        public RespCalComm Commissions { get; set; } = default!;
    }
}