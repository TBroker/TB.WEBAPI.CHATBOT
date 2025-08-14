namespace TB.Chatbot.Domain.Requests
{
    public class ReqThaiPostTracking
    {
        public string? status { get; set; }
        public string? language { get; set; }
        public List<string>? barcode { get; set; }
    }
}