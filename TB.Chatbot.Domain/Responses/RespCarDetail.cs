using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespCarDetail
    {
        [JsonPropertyName("car_engine_size")]
        public IEnumerable<RespCarEngineSize>? respCarEngineSize { get; set; }

        [JsonPropertyName("car_year")]
        public IEnumerable<RespCarYear>? respCarYear { get; set; }

        [JsonPropertyName("coverage_type")]
        public IEnumerable<RespCoverType>? respCoverType { get; set; }
    }
}