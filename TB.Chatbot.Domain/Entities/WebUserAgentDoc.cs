using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_user_agent_doc")]
    public class WebUserAgentDoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        public DateTime date_create { get; set; }
        public DateTime date_update { get; set; }
        public string? UserID { get; set; }
        public string? DocStatus { get; set; }
        public string? last_user { get; set; }
        public DateTime approve_date { get; set; }
        public string? mail_sent { get; set; }
    }
}