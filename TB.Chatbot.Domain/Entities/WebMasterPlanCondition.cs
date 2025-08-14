using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_master_plan_condition")]
    public class WebMasterPlanCondition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? product_code { get; set; }
        public string? company_code { get; set; }
        public string? group_agent { get; set; }
        public string? business_type { get; set; }
        public string? profit_sharing { get; set; }
    }
}
