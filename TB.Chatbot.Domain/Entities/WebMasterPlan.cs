using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_master_plan")]
    public class WebMasterPlan
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

        [JsonPropertyName("tm_product_code")]
        public string? TM_PRODUCT_CODE { get; set; }

        public string? title { get; set; }
        public string? en_title { get; set; }
        public string? TM_PRODUCT_CODE_OIC { get; set; }
        public string? TM_PRODUCT_DST_GROUP { get; set; }
        public string? coverage_code { get; set; }
        public string? company_code { get; set; }
        public string? origianl_product_code { get; set; }
        public string? repair_type { get; set; }
        public string? group_agent { get; set; }
        public string? business_type { get; set; }
        public string? profit_sharing_code { get; set; }
        public string? effective_date { get; set; }
        public string? expire_date { get; set; }
        public string? cover_val1 { get; set; }
        public string? cover_val2 { get; set; }
        public string? cover_val3 { get; set; }
        public string? cover_val4 { get; set; }
        public string? cover_val5 { get; set; }
        public string? cover_val6 { get; set; }
        public string? cover_val7 { get; set; }
        public string? cover_val8 { get; set; }
        public string? cover_val9 { get; set; }
        public string? cover_val10 { get; set; }
        public string? cover_val11 { get; set; }
        public string? cover_val12 { get; set; }
        public string? cover_val13 { get; set; }
        public string? cover_val14 { get; set; }
        public string? cover_val15 { get; set; }
        public string? cover_val16 { get; set; }
        public string? cover_val17 { get; set; }
        public string? cover_val18 { get; set; }
        public string? cover_val19 { get; set; }
        public string? cover_val20 { get; set; }
        public string? en_cover_val1 { get; set; }
        public string? en_cover_val2 { get; set; }
        public string? en_cover_val3 { get; set; }
        public string? en_cover_val4 { get; set; }
        public string? en_cover_val5 { get; set; }
        public string? en_cover_val6 { get; set; }
        public string? en_cover_val7 { get; set; }
        public string? en_cover_val8 { get; set; }
        public string? en_cover_val9 { get; set; }
        public string? en_cover_val10 { get; set; }
        public string? en_cover_val11 { get; set; }
        public string? en_cover_val12 { get; set; }
        public string? en_cover_val13 { get; set; }
        public string? en_cover_val14 { get; set; }
        public string? en_cover_val15 { get; set; }
        public string? en_cover_val16 { get; set; }
        public string? en_cover_val17 { get; set; }
        public string? en_cover_val18 { get; set; }
        public string? en_cover_val19 { get; set; }
        public string? en_cover_val20 { get; set; }
        public string? pb_TM_PRODUCT_CODE { get; set; }
        public string? pb_title { get; set; }
        public string? pb_en_title { get; set; }
        public string? pb_TM_PRODUCT_CODE_OIC { get; set; }
        public string? pb_TM_PRODUCT_DST_GROUP { get; set; }
        public string? pb_coverage_code { get; set; }
        public string? pb_company_code { get; set; }
        public string? pb_origianl_product_code { get; set; }
        public string? pb_repair_type { get; set; }
        public string? pb_group_agent { get; set; }
        public string? pb_business_type { get; set; }
        public string? pb_profit_sharing_code { get; set; }
        public string? pb_effective_date { get; set; }
        public string? pb_expire_date { get; set; }
        public string? pb_cover_val1 { get; set; }
        public string? pb_cover_val2 { get; set; }
        public string? pb_cover_val3 { get; set; }
        public string? pb_cover_val4 { get; set; }
        public string? pb_cover_val5 { get; set; }
        public string? pb_cover_val6 { get; set; }
        public string? pb_cover_val7 { get; set; }
        public string? pb_cover_val8 { get; set; }
        public string? pb_cover_val9 { get; set; }
        public string? pb_cover_val10 { get; set; }
        public string? pb_cover_val11 { get; set; }
        public string? pb_cover_val12 { get; set; }
        public string? pb_cover_val13 { get; set; }
        public string? pb_cover_val14 { get; set; }
        public string? pb_cover_val15 { get; set; }
        public string? pb_cover_val16 { get; set; }
        public string? pb_cover_val17 { get; set; }
        public string? pb_cover_val18 { get; set; }
        public string? pb_cover_val19 { get; set; }
        public string? pb_cover_val20 { get; set; }
        public string? pb_en_cover_val1 { get; set; }
        public string? pb_en_cover_val2 { get; set; }
        public string? pb_en_cover_val3 { get; set; }
        public string? pb_en_cover_val4 { get; set; }
        public string? pb_en_cover_val5 { get; set; }
        public string? pb_en_cover_val6 { get; set; }
        public string? pb_en_cover_val7 { get; set; }
        public string? pb_en_cover_val8 { get; set; }
        public string? pb_en_cover_val9 { get; set; }
        public string? pb_en_cover_val10 { get; set; }
        public string? pb_en_cover_val11 { get; set; }
        public string? pb_en_cover_val12 { get; set; }
        public string? pb_en_cover_val13 { get; set; }
        public string? pb_en_cover_val14 { get; set; }
        public string? pb_en_cover_val15 { get; set; }
        public string? pb_en_cover_val16 { get; set; }
        public string? pb_en_cover_val17 { get; set; }
        public string? pb_en_cover_val18 { get; set; }
        public string? pb_en_cover_val19 { get; set; }
        public string? pb_en_cover_val20 { get; set; }
        public string? sub_insure { get; set; }
        public string? pb_sub_insure { get; set; }
    }
}