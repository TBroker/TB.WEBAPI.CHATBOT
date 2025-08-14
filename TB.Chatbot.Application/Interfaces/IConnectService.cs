namespace TB.Chatbot.Application.Interfaces
{
    public interface IConnectService
    {
        Task<HttpResponseMessage> ResponseTMCSContent(string _url, object _dataJson);

        Task<HttpResponseMessage> ResponseThaiPostContent(string _url, object _dataJson);
    }
}