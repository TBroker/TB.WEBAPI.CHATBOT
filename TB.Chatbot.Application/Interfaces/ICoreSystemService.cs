using TB.Chatbot.Domain.Reponses;
using TB.Chatbot.Domain.Requests;

namespace TB.Chatbot.Application.Interfaces
{
    public interface ICoreSystemService
    {
        Task<RespMessage> GetAgent(ReqAgent reqAgent);

        Task<RespMessage> FetchDataInstallment(ReqInstallmentList reqInstallmentList);

        Task<RespMessage> FetchDataInstallmentDetail(ReqInstallmentDetail reqInstallmentDetail);

        Task<RespMessage> FetchDataInstallmentQrCode(ReqInstallmentQRCode reqInstallmentQRCode);
    }
}