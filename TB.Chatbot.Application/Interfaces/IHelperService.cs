namespace TB.Chatbot.Application.Interfaces
{
    public interface IHelperService
    {
        Task<string> GetDescription(Enum value);

        Task<string> GetBusinessType(string businessType);
    }
}