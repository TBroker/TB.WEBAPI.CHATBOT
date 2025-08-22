using Newtonsoft.Json;
using System.Net;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Enums;
using TB.Chatbot.Domain.Reponses;
using TB.Chatbot.Domain.Requests;

namespace TB.Chatbot.Application.Services
{
    public class WebDataService(IWebDataRepository webDataRepository, IHelperService helperService, ICoreSystemService coreSystemService) : IWebDataService
    {
        private readonly ICoreSystemService _coreSystemService = coreSystemService;
        private readonly IWebDataRepository _webDataRepository = webDataRepository;
        private readonly IHelperService _helperService = helperService;

        public async Task<RespMessage> GetDataCarBrand()
        {
            var results = await _webDataRepository.GetDataCarBrand();
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> GetDataCarModel(ReqCarModel reqCarModel)
        {
            var results = await _webDataRepository.GetDataCarModel(reqCarModel);
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> GetDataCarDetail(ReqCarDetail reqCarDetail)
        {
            var reqCarEngineSize = new ReqCarEngineSize() { car_brand = reqCarDetail.car_brand, car_model = reqCarDetail.car_model };
            var reqCarYear = new ReqCarYear() { car_brand = reqCarDetail.car_brand, car_model = reqCarDetail.car_model };
            var reqCoverType = new ReqCoverType() { car_brand = reqCarDetail.car_brand, car_model = reqCarDetail.car_model };

            var results = await _webDataRepository.GetDataCarEngineSize(reqCarEngineSize);
            var results1 = await _webDataRepository.GetDataCarYear(reqCarYear);
            var results2 = await _webDataRepository.GetDataCoverageType(reqCoverType);

            var respCarDetail = new RespCarDetail()
            {
                respCarEngineSize = results,
                respCarYear = results1,
                respCoverType = results2,
            };

            var list = new List<RespCarDetail>
            {
                respCarDetail
            };
            return await ResponseMessageContent(list, list.Count != 0);
        }

        public async Task<RespMessage> GetDataCarEngineSize(ReqCarEngineSize reqCarEngineSize)
        {
            var results = await _webDataRepository.GetDataCarEngineSize(reqCarEngineSize);
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> GetDataCarYear(ReqCarYear reqCarYear)
        {
            var results = await _webDataRepository.GetDataCarYear(reqCarYear);
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> GetDataCoverageType(ReqCoverType reqCoverType)
        {
            var results = await _webDataRepository.GetDataCoverageType(reqCoverType);
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> GetDataCoverageType()
        {
            var results = await _webDataRepository.GetDataCoverageType();
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> GetDataCompany()
        {
            var results = await _webDataRepository.GetDataCompany();
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> GetDataAutoMobile()
        {
            var results = await _webDataRepository.GetDataAutoMobile();
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> GetDataFilterComm()
        {
            var results = await _webDataRepository.GetDataCoverageType();
            var results1 = await _webDataRepository.GetDataCompany();
            var results2 = await _webDataRepository.GetDataAutoMobile();

            var respFilterComm = new RespFilterComm()
            {
                respCoverTypes = results,
                respCompanies = results1,
                respAutoMobiles = results2,
            };

            var list = new List<RespFilterComm>
            {
                respFilterComm
            };
            return await ResponseMessageContent(list, list.Count != 0);
        }

        public async Task<RespMessage> GetDataProduct(ReqProduct reqProduct)
        {
            var results = await _webDataRepository.GetDataProduct(reqProduct);
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> GetDataPremiumsList(ReqPremiumList reqPremiumList)
        {
            var results = await _webDataRepository.GetDataPremiumsList(reqPremiumList);
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> GetDataPremiums(ReqPremium reqPremium)
        {
            if (reqPremium.premium_id!.Count() > 4)
                return new RespMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = await _helperService.GetDescription(ContentMessage.NoMoreThan4Item),
                    Status = StatusMessage.Fail.ToString(),
                    Result = new List<object>(),
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };

            var list = new List<RespPremium>();
            foreach (var _reqPremium in reqPremium.premium_id!)
            {
                var premiums = await _webDataRepository.GetDataPremiums(_reqPremium.id!);
                premiums.respCoverText = await _webDataRepository.GetDataCoverText(
                    new ReqCoverText
                    {
                        premium_id = _reqPremium.id,
                        tm_product_code = premiums.tm_product_code,
                        company_code = premiums.company_code,
                        coverage_code = premiums.coverage_code
                    });

                premiums.respCalComm = await CalculationComm(new ReqCalComm
                {
                    userid = reqPremium.userid,
                    atm_type = premiums.atm_type,
                    company_code = premiums.company_code,
                    product_code = premiums.tm_product_code,
                    total_amount_vmi = (double)premiums.total_premiums,
                    total_amount_cmi = (double)premiums.cmi_total_premiums
                });

                list.Add(premiums);
            }
            return await ResponseMessageContent(list, list.Count != 0);
        }

        public async Task<RespMessage> GetDataUser(ReqUser reqUser)
        {
            var results = await _webDataRepository.GetDataUser(reqUser);
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> CalculationPremium(ReqCalComm reqCalComm)
        {
            try
            {
                var comm = await CalculationComm(reqCalComm);
                var list = new List<RespCalComm>
                {
                    comm
                };

                return await ResponseMessageContent(list, list.Count != 0);
            }
            catch
            {
                return await ResponseMessageContent(new List<RespCalComm>(), false);
            }
        }

        public async Task<RespMessage> GetDataTracking(ReqDataTracking reqDataTracking)
        {
            var results = await _webDataRepository.GetDataTracking(reqDataTracking);
            return await ResponseMessageContent(results, results.Any());
        }

        public async Task<RespMessage> InsertQuotations(ReqOrderMotor reqOrderMotor)
        {
            var results = await _webDataRepository.InsertOrderMotor(reqOrderMotor);
            return await ResponseMessageContent(results, results.Status, ApplicationType.Commmand);
        }

        private async Task<RespCalComm> CalculationComm(ReqCalComm reqCalComm)
        {
            try
            {
                var results = await _webDataRepository.CalculationPremium(reqCalComm);

                var agent = await _coreSystemService.GetAgent(new ReqAgent { AGENT_CODE = reqCalComm.userid });
                var serAgent = JsonConvert.SerializeObject(agent);
                var jsonSerAgent = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<RespMessage>(serAgent)!.Result);
                var jsonDeAgent = JsonConvert.DeserializeObject<IEnumerable<RespAgent>>(jsonSerAgent)!.FirstOrDefault()!;
                var wth_r = jsonDeAgent.W_TAX_RATE / 100;
                var vat_r = jsonDeAgent.VAT_RATE / 100;

                var cal_net = 1.07428;
                var net_total_vmi = Double.Parse(Convert.ToDouble(reqCalComm.total_amount_vmi / cal_net).ToString("0.##").Split(".")[0]);
                results.net_comm = Double.Parse(Convert.ToDouble(net_total_vmi * (results.comm_percent / 100)).ToString("0.##"));
                results.total_comm = Double.Parse(Convert.ToDouble((results.net_comm - (results.net_comm * wth_r)) + (results.net_comm * vat_r)).ToString("0.##"));
                results.delivery_amount = Double.Parse(Convert.ToDouble((reqCalComm.total_amount_vmi) - results.total_comm).ToString("0.##"));

                var net_total_cmi = Double.Parse(Convert.ToDouble(reqCalComm.total_amount_cmi / cal_net).ToString("0.##").Split(".")[0]);
                results.cmi_net_comm = Double.Parse(Convert.ToDouble(net_total_cmi * (results.cmi_comm_percent / 100)).ToString("0.##"));
                results.cmi_total_comm = Double.Parse(Convert.ToDouble((results.cmi_net_comm - (results.cmi_net_comm * wth_r)) + (results.cmi_net_comm * vat_r)).ToString("0.##"));
                results.cmi_delivery_amount = Double.Parse(Convert.ToDouble((reqCalComm.total_amount_cmi) - results.cmi_total_comm).ToString("0.##"));

                results.total_comm_amount = Convert.ToDouble((results.total_comm + results.cmi_total_comm).ToString("0.##"));
                results.total_delivery_amount = Convert.ToDouble((results.delivery_amount + results.cmi_delivery_amount).ToString("0.##"));
                return results;
            }
            catch
            {
                return new RespCalComm();
            }
        }

        public async Task<RespMessage> GetRewardPoint(ReqUser reqUser)
        {
            var results = await _webDataRepository.GetRewardPoint(reqUser);
            return await ResponseMessageContent(results, !string.IsNullOrEmpty(results.UserId));
        }

        public async Task<RespMessage> GetSubInsurance(ReqFilterCoverage request)
        {
            var results = await _webDataRepository.GetSubInsurance(request);
            return await ResponseMessageContent(results, results != null);
        }

        private async Task<RespMessage> ResponseMessageContent(object results, bool isContent, ApplicationType applicationType = ApplicationType.Query)
        {
            try
            {
                if (isContent)
                    return new RespMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = await _helperService.GetDescription(ContentMessage.Ok),
                        Status = StatusMessage.Success.ToString(),
                        Result = results,
                        Timestamp = DateTime.Now,
                        TransactionID = Guid.NewGuid()
                    };

                return new RespMessage
                {
                    StatusCode = applicationType != ApplicationType.Commmand ? HttpStatusCode.NoContent : HttpStatusCode.BadRequest,
                    Message = applicationType != ApplicationType.Commmand ? await _helperService.GetDescription(ContentMessage.NoContent) : await _helperService.GetDescription(ContentMessage.BadRequest),
                    Status = applicationType != ApplicationType.Commmand ? StatusMessage.Success.ToString() : StatusMessage.Fail.ToString(),
                    Result = results,
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
            catch
            {
                return new RespMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = await _helperService.GetDescription(ContentMessage.InternalServerError),
                    Status = StatusMessage.Fail.ToString(),
                    Result = new List<object>(),
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
        }
    }
}