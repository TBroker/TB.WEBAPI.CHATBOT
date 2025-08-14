using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespMessageTMCS
    {
        [JsonPropertyName("result")]
        public string? Result { get; set; }

        [JsonPropertyName("errormsg")]
        public string? ErrorMsg { get; set; }

        [JsonPropertyName("transdatetime")]
        public string? TransDateTime { get; set; }
    }
}