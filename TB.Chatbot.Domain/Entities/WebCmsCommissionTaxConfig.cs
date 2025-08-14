using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_cms_commission_tax_config")]
    public class WebCmsCommissionTaxConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        public decimal lastcreate { get; set; }
        public decimal lastupdate { get; set; }
        public decimal sort { get; set; }
        public decimal status { get; set; }
        public string? pb_status { get; set; }
        public string? last_user { get; set; }
        public string? pb_last_user { get; set; }
        public decimal show_front { get; set; }
        public string? title { get; set; }
        public string? en_title { get; set; }
        public string? config_value { get; set; }
        public string? pb_title { get; set; }
        public string? pb_en_title { get; set; }
        public string? pb_config_value { get; set; }
    }
}