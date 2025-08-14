namespace TB.Chatbot.Domain.Requests
{
    public class ReqPremiumList
    {
        public string? car_brand { get; set; }
        public string? car_model { get; set; }
        public string? coverage_code { get; set; }
        public string? car_year { get; set; }
        public string? car_engine_size { get; set; }
        public int sum_insured { get; set; }
        public int od { get; set; }
        public int f_t { get; set; }
        public int s_p { get; set; }
        public string? userid { get; set; }
    }
}