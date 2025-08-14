using TB.Chatbot.Domain.Reponses;
using TB.Chatbot.Domain.Requests;

namespace TB.Chatbot.Application.Interfaces
{
    public interface IWebDataService
    {
        Task<RespMessage> GetDataCarBrand();

        Task<RespMessage> GetDataCarModel(ReqCarModel reqCarModel);

        Task<RespMessage> GetDataCarDetail(ReqCarDetail reqCarDetail);

        Task<RespMessage> GetDataCarEngineSize(ReqCarEngineSize reqCarEngineSize);

        Task<RespMessage> GetDataCarYear(ReqCarYear reqCarYear);

        Task<RespMessage> GetDataCoverageType(ReqCoverType reqCoverType);

        Task<RespMessage> GetDataCoverageType();

        Task<RespMessage> GetDataCompany();

        Task<RespMessage> GetDataAutoMobile();

        Task<RespMessage> GetDataProduct(ReqProduct reqProduct);

        Task<RespMessage> GetDataPremiumsList(ReqPremiumList reqPremiumList);

        Task<RespMessage> GetDataPremiums(ReqPremium reqPremium);

        Task<RespMessage> GetDataUser(ReqUser reqUser);

        Task<RespMessage> CalculationPremium(ReqCalComm reqCalComm);

        Task<RespMessage> GetDataFilterComm();

        Task<RespMessage> GetDataTracking(ReqDataTracking reqDataTracking);

        Task<RespMessage> GetRewardPoint(ReqUser reqUser);

        Task<RespMessage> InsertQuotations(ReqOrderMotor reqOrderMotor);
    }
}