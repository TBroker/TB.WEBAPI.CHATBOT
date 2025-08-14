using System.Net;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespMessage
    {
        [JsonPropertyName("statuscode")]
        public HttpStatusCode StatusCode { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("result")]
        public object? Result { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("transactionid")]
        public Guid TransactionID { get; set; }
    }
}