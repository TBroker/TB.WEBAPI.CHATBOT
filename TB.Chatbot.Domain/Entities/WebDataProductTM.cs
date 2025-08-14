using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_data_product_tm")]
    public class WebDataProductTM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal? id { get; set; }

        public DateTime? date_create { get; set; }
        public DateTime? date_update { get; set; }
        public string? INS_Name { get; set; }
        public string? TM_PRODUCT_CODE { get; set; }
        public string? TM_PRODUCT_DST { get; set; }
        public string? TM_PRODUCT_DST_GROUP { get; set; }
        public string? TM_PRODUCT_CODE_OIC { get; set; }
        public string? TM_PRODUCT_OIC { get; set; }
    }
}