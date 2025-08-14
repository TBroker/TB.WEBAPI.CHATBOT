using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TB.Chatbot.Domain.Responses
{
    public class ResInstallmentList
    {
        [JsonProperty("AGENT_CODE")]
        [JsonPropertyName("agent_code")]
        public string? AgentCode { get; set; }

        [JsonProperty("AGENT_NAME")]
        [JsonPropertyName("agent_name")]
        public string? AgentName { get; set; }

        [JsonProperty("APP_NO")]
        [JsonPropertyName("app_no")]
        public string? AppNo { get; set; }

        [JsonProperty("POLICY_NO")]
        [JsonPropertyName("policy_no")]
        public string? PolicyNo { get; set; }

        [JsonProperty("COMPANY_CODE")]
        [JsonPropertyName("company_code")]
        public string? CompanyCode { get; set; }

        [JsonProperty("INS_COMP_NAME_T")]
        [JsonPropertyName("ins_comp_name_t")]
        public string? InsCompanyNameT { get; set; }

        [JsonProperty("INS_NAME")]
        [JsonPropertyName("ins_name")]
        public string? InsName { get; set; }

        [JsonProperty("INS_START_DATE")]
        [JsonPropertyName("ins_start_date")]
        public string? InsStartDate { get; set; }

        [JsonProperty("INS_END_DATE")]
        [JsonPropertyName("ins_end_date")]
        public string? InsEndDate { get; set; }

        [JsonProperty("CARREG_NO")]
        [JsonPropertyName("carreg_no")]
        public string? CarRegNo { get; set; }

        [JsonProperty("SUM_TOTAL_PREM_AMT")]
        [JsonPropertyName("sum_total_prem_amt")]
        public double? SumTotalPremAmt { get; set; }

        [JsonProperty("INSTALLMENT")]
        [JsonPropertyName("installment")]
        public int? Installment { get; set; }

        [JsonProperty("TOTAL_PREM_AMT")]
        [JsonPropertyName("total_prem_amt")]
        public double? TotalPremAmt { get; set; }

        [JsonProperty("NUM_INSTL_PAYIN")]
        [JsonPropertyName("num_instl_payin")]
        public int? NumInstlPayin { get; set; }

        [JsonProperty("SUM_PAYIN_AMT")]
        [JsonPropertyName("sum_payin_amt")]
        public double? SumPayinAmt { get; set; }

        [JsonProperty("NUM_INSTL_NOT_PAYIN")]
        [JsonPropertyName("num_instl_not_payin")]
        public int? NumInstlNotPayin { get; set; }

        [JsonProperty("SUM_NOT_PAYIN_AMT")]
        [JsonPropertyName("sum_not_payin_amt")]
        public double? SumNotPayinAmt { get; set; }

        [JsonProperty("DUEDATE")]
        [JsonPropertyName("duedate")]
        public string? Duedate { get; set; }

        [JsonProperty("DUEDATE_INSTALLMENT_NO")]
        [JsonPropertyName("duedate_installment_no")]
        public int? DuedateInstallmentNo { get; set; }

        [JsonProperty("POLICY_STATUS")]
        [JsonPropertyName("policy_status")]
        public string? PolicyStatus { get; set; }
    }
}
