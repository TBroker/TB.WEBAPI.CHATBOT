using System.Text.Json.Serialization;
using static TB.Chatbot.Domain.Reponses.RespThaiPostTracking;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespTracking
    {
        [JsonPropertyName("name_insurance")]
        public string? NameInsurance { get; set; }

        [JsonPropertyName("car_registration")]
        public string? CarRegistration { get; set; }

        [JsonPropertyName("items")]
        public Detail? Items { get; set; }

        public class Detail
        {
            [JsonPropertyName("detail_tracking")]
            public List<ItemData>? DetailTracking { get; set; }
        }
    }
}