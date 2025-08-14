using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_data_commission_rate")]
    public class WebDataCommissionRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        public DateTime date_create { get; set; }
        public DateTime date_update { get; set; }
        public string? company_code { get; set; }
        public string? group_agent_code { get; set; }
        public string? group_agent { get; set; }

        [JsonPropertyName("tm_product_code")]
        public string? TM_PRODUCT_CODE { get; set; }

        public string? comm_insure { get; set; }
        public string? comm_sale_service { get; set; }
        public string? comm_product_profit { get; set; }
        public string? comm_other { get; set; }

        [JsonPropertyName("tm_product_dst_group")]
        public string? TM_PRODUCT_DST_GROUP { get; set; }

        [JsonPropertyName("account_type")]
        public string? ACCOUNT_TYPE { get; set; }

        public string? service_rate_agency { get; set; }
    }
}