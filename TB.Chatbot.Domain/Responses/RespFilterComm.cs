using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespFilterComm
    {
        [JsonPropertyName("coverage_type")]
        public IEnumerable<RespCoverType>? respCoverTypes { get; set; }

        [JsonPropertyName("company")]
        public IEnumerable<RespCompany>? respCompanies { get; set; }

        [JsonPropertyName("automobile_type")]
        public IEnumerable<RespAutoMobile>? respAutoMobiles { get; set; }
    }
}