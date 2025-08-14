using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_quo_remark")]
    public class WebQuoRemark
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int? lastcreate { get; set; }
        public int? lastupdate { get; set; }
        public string? lastcreate_s { get; set; }
        public string? lastupdate_s { get; set; }
        public int? sort { get; set; }
        public int? status { get; set; }
        public int? pb_status { get; set; }
        public string? last_user { get; set; }
        public string? pb_last_user { get; set; }
        public int? show_front { get; set; }
        public string? title { get; set; }
        public string? en_title { get; set; }
        public string? TM_PRODUCT_DST_GROUP { get; set; }
        public string? info { get; set; }
        public string? en_info { get; set; }
        public string? pb_title { get; set; }
        public string? pb_en_title { get; set; }
        public string? pb_TM_PRODUCT_DST_GROUP { get; set; }
        public string? pb_info { get; set; }
        public string? pb_en_info { get; set; }
    }
}