using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_user_agent_doc_detail")]
    public class WebUserAgentDocDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        public DateTime date_create { get; set; }
        public DateTime date_update { get; set; }
        public decimal doc_id { get; set; }
        public string? DocCode { get; set; }
        public string? DocNo { get; set; }
        public string? DocStart { get; set; }
        public string? DocExpire { get; set; }
        public string? FileName { get; set; }
        public string? FileStatus { get; set; }
        public string? DocRemark { get; set; }
        public string? DocEffect { get; set; }
    }
}