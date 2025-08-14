using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespAgent
    {
        [JsonPropertyName("agent_code")]
        public string? AGENT_CODE { get; set; }

        [JsonPropertyName("name")]
        public string? NAME { get; set; }

        [JsonPropertyName("expire_date")]
        public string? EXPIRE_DATE { get; set; }

        [JsonPropertyName("numexpire")]
        public string? NUMEXPIRE { get; set; }

        [JsonPropertyName("flag_nonlife_doc")]
        public string? FLAG_NONLIFE_DOC { get; set; }

        [JsonPropertyName("active")]
        public string? ACTIVE { get; set; }

        [JsonPropertyName("belong_to")]
        public string? BELONG_TO { get; set; }

        [JsonPropertyName("agent_type")]
        public string? AGENT_TYPE { get; set; }

        [JsonPropertyName("agent_type_desc")]
        public string? AGENT_TYPE_DESC { get; set; }

        [JsonPropertyName("ac_type_code")]
        public string? AC_TYPE_CODE { get; set; }

        [JsonPropertyName("ac_type_desc")]
        public string? AC_TYPE_DESC { get; set; }

        [JsonPropertyName("channel_code")]
        public string? CHANNEL_CODE { get; set; }

        [JsonPropertyName("channel_desc")]
        public string? CHANNEL_DESC { get; set; }

        [JsonPropertyName("channel_running")]
        public string? CHANNEL_RUNNING { get; set; }

        [JsonPropertyName("f_address_no")]
        public string? F_ADDRESS_NO { get; set; }

        [JsonPropertyName("f_soi")]
        public string? F_SOI { get; set; }

        [JsonPropertyName("f_street")]
        public string? F_STREET { get; set; }

        [JsonPropertyName("f_district_code_sub")]
        public string? F_DISTRICT_CODE_SUB { get; set; }

        [JsonPropertyName("f_subdistrict")]
        public string? F_SUBDISTRICT { get; set; }

        [JsonPropertyName("f_district_code")]
        public string? F_DISTRICT_CODE { get; set; }

        [JsonPropertyName("district_name_t")]
        public string? DISTRICT_NAME_T { get; set; }

        [JsonPropertyName("f_province_code")]
        public string? F_PROVINCE_CODE { get; set; }

        [JsonPropertyName("prov_name_t")]
        public string? PROV_NAME_T { get; set; }

        [JsonPropertyName("f_zipcode")]
        public string? F_ZIPCODE { get; set; }

        [JsonPropertyName("f_phone")]
        public string? F_PHONE { get; set; }

        [JsonPropertyName("f_faxno")]
        public string? F_FAXNO { get; set; }

        [JsonPropertyName("e_mail_addr")]
        public string? E_MAIL_ADDR { get; set; }

        [JsonPropertyName("f_credit")]
        public string? F_CREDIT { get; set; }

        [JsonPropertyName("w_tax_rate")]
        public double? W_TAX_RATE { get; set; }

        [JsonPropertyName("vat_rate")]
        public double? VAT_RATE { get; set; }
    }
}