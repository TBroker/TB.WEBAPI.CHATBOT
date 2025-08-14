namespace TB.Chatbot.Domain.Reponses
{
    public class RespPremiumList
    {
        public int id { get; set; }
        public string? tm_product_code { get; set; }
        public string? title_masterplan { get; set; }
        public string? coverage_code { get; set; }
        public string? coverage_name { get; set; }
        public string? company_code { get; set; }
        public string? company_name { get; set; }
        public string? company_image { get; set; }
        public string? repair_type { get; set; }
        public string? repair_name { get; set; }
        public string? car_brand { get; set; }
        public string? car_model { get; set; }
        public string? car_year { get; set; }
        public string? car_engine_size { get; set; }
        public int sum_insure { get; set; }
        public int od { get; set; }
        public int f_t { get; set; }
        public int s_p { get; set; }
        public string? atm_type { get; set; }
        public decimal net_premiums { get; set; }
        public decimal stamp { get; set; }
        public decimal tax { get; set; }
        public decimal total_premiums { get; set; }
        public decimal cmi_net_premiums { get; set; }
        public decimal cmi_stamp { get; set; }
        public decimal cmi_tax { get; set; }
        public decimal cmi_total_premiums { get; set; }
        public decimal total_premiums_with_cmi { get; set; }
    }
}