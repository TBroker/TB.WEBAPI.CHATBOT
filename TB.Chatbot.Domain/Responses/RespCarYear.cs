using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespCarYear
    {
        [JsonPropertyName("year")]
        public string? car_year { get; set; }
    }
}