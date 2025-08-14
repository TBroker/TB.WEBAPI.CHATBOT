using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Requests
{
    public class ReqDataTracking
    {
        [JsonPropertyName("name_ins")]
        public string? NameIns { get; set; }

        [JsonPropertyName("car_regis")]
        public string? CarRegis { get; set; }
    }
}