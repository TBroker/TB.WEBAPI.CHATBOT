using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_data_reward_point")]
    public class WebDataRewardPoint
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

        [Column("agent_code")]
        [JsonPropertyName("agent_code")]
        [JsonProperty("agent_code")]
        public string? AgentCode { get; set; }

        [Column("point")]
        [JsonPropertyName("point")]
        [JsonProperty("point")]
        public decimal? Point { get; set; }

        [Column("point_focus")]
        [JsonPropertyName("point_focus")]
        [JsonProperty("point_focus")]
        public decimal? PointFocus { get; set; }

        [Column("point_plus")]
        [JsonPropertyName("point_plus")]
        [JsonProperty("point_plus")]
        public decimal? PointPlus { get; set; }

        [Column("point_monthly")]
        [JsonPropertyName("point_monthly")]
        [JsonProperty("point_monthly")]
        public decimal? PointMonthly { get; set; }
    }
}
