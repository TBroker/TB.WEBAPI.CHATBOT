using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_cms_reward_point")]
    public class WebCmsRewardPoint
    {
        [Column("transaction_id")]
        [JsonPropertyName("transaction_id")]
        [JsonProperty("transaction_id")]
        public string? TransactionId { get; set; }

        [Column("date_create")]
        [JsonPropertyName("date_create")]
        [JsonProperty("date_create")]
        public DateTime? DateCreate { get; set; }

        [Column("date_update")]
        [JsonPropertyName("date_update")]
        [JsonProperty("date_update")]
        public DateTime? DateUpdate { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [JsonPropertyName("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Column("header")]
        [JsonPropertyName("header")]
        [JsonProperty("header")]
        public string? Header { get; set; }

        [Column("description")]
        [JsonPropertyName("description")]
        [JsonProperty("description")]
        public string? Description { get; set; }

        [Column("file_path_image")]
        [JsonPropertyName("file_path_image")]
        [JsonProperty("file_path_image")]
        public string? FilePathImage { get; set; }

        [Column("point")]
        [JsonPropertyName("point")]
        [JsonProperty("point")]
        public decimal? Point { get; set; }

        [Column("unit_pointed")]
        [JsonPropertyName("unit_pointed")]
        [JsonProperty("unit_pointed")]
        public string? UnitPointed { get; set; }

        [Column("point_focus")]
        [JsonPropertyName("point_focus")]
        [JsonProperty("point_focus")]
        public decimal? PointFocus { get; set; }

        [Column("date_start")]
        [JsonPropertyName("date_start")]
        [JsonProperty("date_start")]
        public DateTime? DateStart { get; set; }

        [Column("date_end")]
        [JsonPropertyName("date_end")]
        [JsonProperty("date_end")]
        public DateTime? DateEnd { get; set; }

        [Column("status")]
        [JsonPropertyName("status")]
        [JsonProperty("status")]
        public string? Status { get; set; }
    }
}
