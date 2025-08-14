namespace TB.Chatbot.Application.Interfaces
{
    public interface IAuthConnectService
    {
        Task<HttpResponseMessage> ResponseAuthThaiPostContent(string _url, object _dataJson);
    }
}