using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_company")]
    public class WebCompany
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int lastcreate { get; set; }
        public int lastupdate { get; set; }
        public string? lastcreate_s { get; set; }
        public string? lastupdate_s { get; set; }
        public int sort { get; set; }
        public int status { get; set; }
        public int pb_status { get; set; }
        public string? last_user { get; set; }
        public string? pb_last_user { get; set; }
        public int show_front { get; set; }
        public string? title { get; set; }
        public string? en_title { get; set; }
        public string? product_group { get; set; }
        public string? company_code { get; set; }
        public string? img1 { get; set; }
        public string? pb_title { get; set; }
        public string? pb_en_title { get; set; }
        public string? pb_product_group { get; set; }
        public string? pb_company_code { get; set; }
        public string? pb_img1 { get; set; }
    }
}