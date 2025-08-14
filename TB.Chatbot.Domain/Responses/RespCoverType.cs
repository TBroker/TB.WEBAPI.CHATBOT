using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespCoverType
    {
        [JsonPropertyName("code")]
        public string? coverage_code { get; set; }

        [JsonPropertyName("name")]
        public string? coverage_name { get; set; }
    }
}