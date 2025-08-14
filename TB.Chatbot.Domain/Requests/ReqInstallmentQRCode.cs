using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Requests
{
    public class ReqInstallmentQRCode
    {
        [JsonProperty("AGENT_CODE")]
        [JsonPropertyName("AGENT_CODE")]
        public string? AgentCode { get; set; }

        [JsonProperty("APP_NO")]
        [JsonPropertyName("APP_NO")]
        public string? AppNo { get; set; }
    }
}
