using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_user_agent_doc_type")]
    public class WebUserAgentDocType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        public DateTime date_create { get; set; }
        public DateTime date_update { get; set; }
        public string? DocCode { get; set; }
        public string? DocName { get; set; }
        public string? DocNameEn { get; set; }
    }
}