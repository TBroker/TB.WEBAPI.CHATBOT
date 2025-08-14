using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Requests
{
    public class ReqAgent
    {
        [JsonPropertyName("AGENT_CODE")]
        public string? AGENT_CODE { get; set; }
    }
}