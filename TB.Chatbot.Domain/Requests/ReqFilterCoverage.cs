namespace TB.Chatbot.Domain.Requests
{
    public class ReqFilterCoverage
    {
        public string? car_brand { get; set; }
        public string? car_model { get; set; }
        public string? car_engine_size { get; set; }
        public string? car_year { get; set; }
        public string? coverage_code { get; set; }
        public int od { get; set; }
        public int f_t { get; set; }
        public int s_p { get; set; }
    }
}