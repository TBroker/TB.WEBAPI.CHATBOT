using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Requests
{
    public class ReqInstallmentList
    {
        [JsonProperty("agent_code")]
        [JsonPropertyName("AGENT_CODE")]
        public string? AgentCode { get; set; }

        [JsonProperty("search_from")]
        [JsonPropertyName("SEARCH_FROM")]
        public string? SearchFrom { get; set; }

        [JsonProperty("start_date")]
        [JsonPropertyName("START_DATE")]
        public string? StartDate { get; set; }

        [JsonProperty("end_date")]
        [JsonPropertyName("END_DATE")]
        public string? EndDate { get; set; }

        [JsonProperty("app_no")]
        [JsonPropertyName("APP_NO")]
        public string? AppNo { get; set; }

        [JsonProperty("policy_no")]
        [JsonPropertyName("POLICY_NO")]
        public string? PolicyNo { get; set; }

        [JsonProperty("ins_surname")]
        [JsonPropertyName("INS_SURNAME")]
        public string? InsSurname { get; set; }

        [JsonProperty("car_regno")]
        [JsonPropertyName("CAR_REGNO")]
        public string? CarRegNo { get; set; }
    }
}
