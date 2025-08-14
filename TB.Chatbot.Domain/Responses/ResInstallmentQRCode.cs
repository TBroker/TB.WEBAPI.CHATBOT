using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Responses
{
    public class ResInstallmentQRCode
    {
        [JsonProperty("APP_NO")]
        [JsonPropertyName("app_no")]
        public string? AppNo { get; set; }

        [JsonProperty("INSTALLMENT_NO")]
        [JsonPropertyName("installment_no")]
        public int? InstallmentNo { get; set; }

        [JsonProperty("INS_NAME")]
        [JsonPropertyName("ins_name")]
        public string? InsName { get; set; }

        [JsonProperty("ADDR")]
        [JsonPropertyName("addr")]
        public string? Addr { get; set; }

        [JsonProperty("SUBDISTRIC")]
        [JsonPropertyName("subdistrict")]
        public string? SubDistrict { get; set; }

        [JsonProperty("DISTRICT_NAME_T")]
        [JsonPropertyName("district_name_t")]
        public string? DistrictNameT { get; set; }

        [JsonProperty("PROV_NAME_T")]
        [JsonPropertyName("prov_name_t")]
        public string? ProvinceNameTh { get; set; }

        [JsonProperty("ZIPCODE")]
        [JsonPropertyName("zipcode")]
        public string? ZipCode { get; set; }

        [JsonProperty("CARREG_NO")]
        [JsonPropertyName("carreg_no")]
        public string? CarRegNo { get; set; }

        [JsonProperty("RECEIPT_DATE")]
        [JsonPropertyName("receipt_date")]
        public string? ReceiptDate { get; set; }

        [JsonProperty("DUEDATE")]
        [JsonPropertyName("duedate")]
        public string? DueDate { get; set; }

        [JsonProperty("PAYAS")]
        [JsonPropertyName("payas")]
        public string? PayAs { get; set; }

        [JsonProperty("TOTAL_PREM_AMT")]
        [JsonPropertyName("total_prem_amt")]
        public double? TotalPremAmt { get; set; }

        [JsonProperty("PHONE_NO")]
        [JsonPropertyName("phone_no")]
        public string? PhoneNo { get; set; }
    }
}