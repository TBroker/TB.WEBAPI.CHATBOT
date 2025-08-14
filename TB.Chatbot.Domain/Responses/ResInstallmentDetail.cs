using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Responses
{
    public class ResInstallmentDetail
    {
        [JsonProperty("APP_NO")]
        [JsonPropertyName("app_no")]
        public string? AppNo { get; set; }

        [JsonProperty("POLICY_NO")]
        [JsonPropertyName("policy_no")]
        public string? PolicyNo { get; set; }

        [JsonProperty("INS_COMP_CODE")]
        [JsonPropertyName("ins_comp_code")]
        public string? InsCompCode { get; set; }

        [JsonProperty("INS_COMP_NAME")]
        [JsonPropertyName("ins_comp_name")]
        public string? InsCompName { get; set; }

        [JsonProperty("POLICY_STATUS")]
        [JsonPropertyName("policy_status")]
        public string? PolicyStatus { get; set; }

        [JsonProperty("INS_NAME")]
        [JsonPropertyName("ins_name")]
        public string? InsName { get; set; }

        [JsonProperty("INS_TELEPHONE")]
        [JsonPropertyName("ins_telephone")]
        public string? InsTelephone { get; set; }

        [JsonProperty("CARREG_NO")]
        [JsonPropertyName("carreg_no")]
        public string? CarRegNo { get; set; }

        [JsonProperty("INS_START_DATE")]
        [JsonPropertyName("ins_start_date")]
        public string? InsStartDate { get; set; }

        [JsonProperty("INS_END_DATE")]
        [JsonPropertyName("ins_end_date")]
        public string? InsEndDate { get; set; }

        [JsonProperty("SUM_PREM_AMT")]
        [JsonPropertyName("sum_prem_amt")]
        public double? SumPremAmt { get; set; }

        [JsonProperty("SUM_PAYIN_AMT")]
        [JsonPropertyName("sum_payin_amt")]
        public double? SumPayinAmt { get; set; }

        [JsonProperty("SUM_BAL_AMT")]
        [JsonPropertyName("sum_bal_amt")]
        public double? SumBalAmt { get; set; }

        [JsonProperty("REMARK")]
        [JsonPropertyName("remark")]
        public string? Remark { get; set; }

        [JsonProperty("LAST_PAYIN_INSTALLMENT_NO")]
        [JsonPropertyName("last_payin_installment_no")]
        public int? LastPayinInstallmentNo { get; set; }

        [JsonProperty("DATA")]
        [JsonPropertyName("data")]
        public List<InstallmentData>? Data { get; set; }
    }
    public class InstallmentData
    {
        [JsonProperty("INSTALLMENT_NO")]
        [JsonPropertyName("installment_no")]
        public string? InstallmentNo { get; set; }

        [JsonProperty("TOTAL_PREM_AMT")]
        [JsonPropertyName("total_prem_amt")]
        public double? TotalPremAmt { get; set; }

        [JsonProperty("DUEDATE")]
        [JsonPropertyName("duedate")]
        public string? Duedate { get; set; }

        [JsonProperty("PAY_IN_AMT")]
        [JsonPropertyName("pay_in_amt")]
        public double? PayInAmt { get; set; }

        [JsonProperty("PAY_IN_DATE")]
        [JsonPropertyName("pay_in_date")]
        public string? PayInDate { get; set; }

        [JsonProperty("FLAG_CANCEL")]
        [JsonPropertyName("flag_cancel")]
        public string? FlagCancel { get; set; }

        [JsonProperty("STATUS")]
        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
}
