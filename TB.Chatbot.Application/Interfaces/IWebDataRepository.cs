using TB.Chatbot.Domain.Entities;
using TB.Chatbot.Domain.Reponses;
using TB.Chatbot.Domain.Requests;

namespace TB.Chatbot.Application.Interfaces
{
    public interface IWebDataRepository
    {
        Task<WebUserJWTAuthorized?> GetDataUserToken(ReqUserInfo reqUserInfo);

        Task<IEnumerable<RespCarBrand>> GetDataCarBrand();

        Task<IEnumerable<RespCarModel>> GetDataCarModel(ReqCarModel reqCarModel);

        Task<IEnumerable<RespCarEngineSize>> GetDataCarEngineSize(ReqCarEngineSize reqCarEngineSize);

        Task<IEnumerable<RespCarYear>> GetDataCarYear(ReqCarYear reqCarYear);

        Task<IEnumerable<RespCoverType>> GetDataCoverageType(ReqCoverType reqCoverType);

        Task<IEnumerable<RespCoverType>> GetDataCoverageType();

        Task<IEnumerable<RespCompany>> GetDataCompany();

        Task<IEnumerable<RespPremiumList>> GetDataPremiumsList(ReqPremiumList reqPremiumList);

        Task<RespPremium> GetDataPremiums(string premium_id);

        Task<RespCoverText> GetDataCoverText(ReqCoverText reqCoverText);

        Task<IEnumerable<RespUser>> GetDataUser(ReqUser reqUser);

        Task<RespCalComm> CalculationPremium(ReqCalComm reqCalComm);

        Task<IEnumerable<RespProduct>> GetDataProduct(ReqProduct reqProduct);

        Task<IEnumerable<RespAutoMobile>> GetDataAutoMobile();

        Task<IEnumerable<WebDataTracking>> GetDataTracking(ReqDataTracking reqDataTracking);

        Task<RespAddOrderMotor> InsertOrderMotor(ReqOrderMotor reqOrderMotor);

        Task<RespReward> GetRewardPoint(ReqUser reqUser);
    }
}