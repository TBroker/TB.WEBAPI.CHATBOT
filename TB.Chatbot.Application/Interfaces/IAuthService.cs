namespace TB.Chatbot.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> GetThaiPostToken();
    }
}