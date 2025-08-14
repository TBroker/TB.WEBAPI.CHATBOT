using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespCarEngineSize
    {
        [JsonPropertyName("engine_size")]
        public string? car_engine_size { get; set; }
    }
}