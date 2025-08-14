namespace TB.Chatbot.Domain.Requests
{
    public class ReqPremium
    {
        public string? userid { get; set; }
        public IEnumerable<Premium>? premium_id { get; set; }
    }

    public class Premium
    {
        public string? id { get; set; }
    }
}