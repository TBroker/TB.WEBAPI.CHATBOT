using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_premiums_motor")]
    public class WebPremiumsMotor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        public DateTime date_create { get; set; }
        public DateTime date_update { get; set; }
        public string? company_code { get; set; }

        [JsonPropertyName("tm_product_code")]
        public string? TM_PRODUCT_CODE { get; set; }

        [JsonPropertyName("tm_product_dst_group")]
        public string? TM_PRODUCT_DST_GROUP { get; set; }

        [JsonPropertyName("tm_product_code_oic")]
        public string? TM_PRODUCT_CODE_OIC { get; set; }

        public string? title_masterplan { get; set; }
        public string? en_title_masterplan { get; set; }
        public string? coverage_code { get; set; }
        public string? group_agent { get; set; }
        public string? business_type { get; set; }
        public string? profit_sharing_code { get; set; }
        public string? repair_type { get; set; }
        public string? car_brand { get; set; }
        public string? car_model { get; set; }
        public string? car_sub_model { get; set; }
        public string? car_group { get; set; }
        public string? car_year { get; set; }
        public string? car_engine_size { get; set; }
        public string? sum_insure { get; set; }
        public string? sum_insure_default { get; set; }
        public string? driver_flag { get; set; }
        public string? driver_year_of_birth { get; set; }
        public string? driver_ranges_year_of_birth { get; set; }
        public string? accessory_flag { get; set; }
        public string? accessory_des { get; set; }
        public string? effective_date { get; set; }
        public string? expire_date { get; set; }
        public string? subclass_sos { get; set; }
        public string? subclass_gis { get; set; }
        public string? f_t { get; set; }
        public string? atm_type { get; set; }
        public string? atm_type_txt { get; set; }
        public string? active_year { get; set; }
        public string? active_type { get; set; }
        public string? s_p { get; set; }
        public string? net_premiums { get; set; }
        public string? stamp { get; set; }
        public string? tax { get; set; }
        public string? total_premiums { get; set; }
        public string? cmi_net_premiums { get; set; }
        public string? cmi_stamp { get; set; }
        public string? cmi_tax { get; set; }
        public string? cmi_total_premiums { get; set; }
        public string? total_premiums_with_cmi { get; set; }
        public string? status { get; set; }
        public string? od { get; set; }
    }
}