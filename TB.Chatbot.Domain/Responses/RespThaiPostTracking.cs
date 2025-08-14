using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespThaiPostTracking
    {
        [JsonPropertyName("response")]
        public Response? response { get; set; }

        public class Response
        {
            [JsonPropertyName("Items")]
            public Dictionary<string, List<ItemData>>? items { get; set; }

            [JsonPropertyName("track_count")]
            public TrackCount? track_count { get; set; }
        }

        public class ItemData
        {
            [JsonPropertyName("barcode")]
            public string? barcode { get; set; }

            [JsonPropertyName("status")]
            public string? status { get; set; }

            [JsonPropertyName("status_description")]
            public string? status_description { get; set; }

            [JsonPropertyName("status_date")]
            public string? status_date { get; set; }

            [JsonPropertyName("location")]
            public string? location { get; set; }

            [JsonPropertyName("postcode")]
            public string? postcode { get; set; }

            [JsonPropertyName("delivery_status")]
            public object? delivery_status { get; set; }

            [JsonPropertyName("delivery_description")]
            public object? delivery_description { get; set; }

            [JsonPropertyName("delivery_datetime")]
            public object? delivery_datetime { get; set; }

            [JsonPropertyName("receiver_name")]
            public object? receiver_name { get; set; }

            [JsonPropertyName("signature")]
            public object? signature { get; set; }

            [JsonPropertyName("status_detail")]
            public string? status_detail { get; set; }

            [JsonPropertyName("delivery_officer_name")]
            public object? delivery_officer_name { get; set; }

            [JsonPropertyName("delivery_officer_tel")]
            public object? delivery_officer_tel { get; set; }

            [JsonPropertyName("office_name")]
            public object? office_name { get; set; }

            [JsonPropertyName("office_tel")]
            public object? office_tel { get; set; }

            [JsonPropertyName("call_center_tel")]
            public string? call_center_tel { get; set; }
        }

        public class TrackCount
        {
            [JsonPropertyName("track_date")]
            public string? track_date { get; set; }

            [JsonPropertyName("count_number")]
            public int count_number { get; set; }

            [JsonPropertyName("track_count_limit")]
            public int track_count_limit { get; set; }
        }

        [JsonPropertyName("message")]
        public string? message { get; set; }

        [JsonPropertyName("status")]
        public bool status { get; set; }
    }
}