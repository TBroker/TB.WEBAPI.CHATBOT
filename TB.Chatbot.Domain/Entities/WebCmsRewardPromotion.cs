using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_cms_reward_promotion")]
    public class WebCmsRewardPromotion
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

        [Column("promotion_name")]
        [JsonPropertyName("promotion_name")]
        [JsonProperty("promotion_name")]
        public string? PromotionName { get; set; }

        [Column("flag_new")]
        [JsonPropertyName("flag_new")]
        [JsonProperty("flag_new")]
        public string? FlagNew { get; set; }

        [Column("file_path_image")]
        [JsonPropertyName("file_path_image")]
        [JsonProperty("file_path_image")]
        public string? FilePathImage { get; set; }

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
