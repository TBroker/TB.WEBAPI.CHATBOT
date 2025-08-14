using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespAddOrderMotor
    {
        [JsonPropertyName("quo_number")]
        public string? QuoteNumber { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("status")]
        public bool Status { get; set; }
    }
}