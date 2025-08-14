using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_data_tracking")]
    public class WebDataTracking
    {
        [Column("transaction_id")]
        [JsonPropertyName("transaction_id")]
        public string? TransactionId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("date_create")]
        [JsonPropertyName("date_create")]
        public DateTime? DateCreate { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Column("app_no")]
        [JsonPropertyName("app_no")]
        public string? AppNo { get; set; }

        [Column("contract_no")]
        [JsonPropertyName("contract_no")]
        public string? ContractNo { get; set; }

        [Column("name_insurance")]
        [JsonPropertyName("name_insurance")]
        public string? NameInsurance { get; set; }

        [Column("policy_no")]
        [JsonPropertyName("policy_no")]
        public string? PolicyNo { get; set; }

        [Column("tracking_no")]
        [JsonPropertyName("tracking_no")]
        public string? TrackingNo { get; set; }

        [Column("car_registration")]
        [JsonPropertyName("car_registration")]
        public string? CarRegistration { get; set; }

        [Column("user_id")]
        [JsonPropertyName("user_id")]
        public string? UserId { get; set; }

        [Column("file_name")]
        [JsonPropertyName("file_name")]
        public string? FileName { get; set; }
    }
}