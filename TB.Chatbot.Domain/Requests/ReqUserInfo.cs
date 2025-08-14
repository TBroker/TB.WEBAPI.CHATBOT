using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Requests
{
    public class ReqUserInfo
    {
        [JsonPropertyName("username")]
        public string? UserName { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }
    }
}