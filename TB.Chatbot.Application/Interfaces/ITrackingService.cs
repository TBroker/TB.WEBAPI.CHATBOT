using TB.Chatbot.Domain.Reponses;
using TB.Chatbot.Domain.Requests;

namespace TB.Chatbot.Application.Interfaces
{
    public interface ITrackingService
    {
        Task<RespMessage> ThaiPostTracking(ReqThaiPostTracking reqThaiPostTracking);

        Task<RespMessage> GetDataThaiPostTracking(ReqDataTracking reqDataTracking);
    }
}