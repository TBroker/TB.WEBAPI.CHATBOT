using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_authorization_oauth")]
    public class WebAuthorizationOauth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Column("date_create")]
        [JsonPropertyName("date_create")]
        [JsonProperty("date_create")]
        public DateTime DateCreate { get; set; }

        [Column("date_update")]
        [JsonPropertyName("date_update")]
        [JsonProperty("date_update")]
        public DateTime DateUpdate { get; set; }

        [Column("module")]
        [JsonPropertyName("module")]
        [JsonProperty("module")]
        public string? Module { get; set; }

        [Column("client_id")]
        [JsonPropertyName("client_id")]
        [JsonProperty("client_id")]
        public string? ClientID { get; set; }

        [Column("client_secret")]
        [JsonPropertyName("client_secret")]
        [JsonProperty("client_secret")]
        public string? ClientSecret { get; set; }

        [Column("status")]
        [JsonPropertyName("status")]
        [JsonProperty("status")]
        public string? Status { get; set; }
    }
}