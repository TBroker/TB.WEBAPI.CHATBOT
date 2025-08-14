using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Enums;
using TB.Chatbot.Domain.Reponses;
using TB.Chatbot.Domain.Requests;
using TB.Chatbot.Domain.Responses;

namespace TB.Chatbot.Application.Services
{
    public class CoreSystemService(IConnectService connectService, IHelperService helperService) : ICoreSystemService
    {
        private readonly IConnectService _connectService = connectService;
        private readonly IHelperService _helperService = helperService;

        public async Task<RespMessage> GetAgent(ReqAgent reqAgent)
        {
            try
            {
                var apiURL = $"/apiMaster/agent";
                var responseMessage = await _connectService.ResponseTMCSContent(apiURL, reqAgent);
                var content = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                    return new RespMessage
                    {
                        StatusCode = responseMessage.StatusCode,
                        Message = await _helperService.GetDescription(ContentMessage.Ok),
                        Status = StatusMessage.Success.ToString(),
                        Result = JsonConvert.DeserializeObject<IEnumerable<RespAgent>>(content),
                        Timestamp = DateTime.Now,
                        TransactionID = Guid.NewGuid()
                    };

                return new RespMessage
                {
                    StatusCode = responseMessage.StatusCode,
                    Message = JsonConvert.DeserializeObject<RespMessageTMCS>(content)!.ErrorMsg,
                    Status = StatusMessage.Fail.ToString(),
                    Result = new List<RespAgent>(),
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
            catch (Exception ex)
            {
                return new RespMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Status = StatusMessage.Error.ToString(),
                    Result = new List<RespAgent>(),
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
        }

        public async Task<RespMessage> FetchDataInstallment(ReqInstallmentList reqInstallmentList)
        {
            try
            {
                CultureInfo ThaiCulture = new("th-TH");
                ThaiCulture.DateTimeFormat.Calendar = new ThaiBuddhistCalendar();

                reqInstallmentList.StartDate = Convert.ToDateTime(reqInstallmentList.StartDate).ToString("dd/MM/yyyy", ThaiCulture);
                reqInstallmentList.EndDate = Convert.ToDateTime(reqInstallmentList.EndDate).ToString("dd/MM/yyyy", ThaiCulture);

                var apiURL = $"/apiInstallment/Report_Installment";
                var responseMessage = await _connectService.ResponseTMCSContent(apiURL, reqInstallmentList);
                var content = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                    return new RespMessage
                    {
                        StatusCode = responseMessage.StatusCode,
                        Message = await _helperService.GetDescription(ContentMessage.Ok),
                        Status = StatusMessage.Success.ToString(),
                        Result = JsonConvert.DeserializeObject<IEnumerable<ResInstallmentList>>(content),
                        Timestamp = DateTime.Now,
                        TransactionID = Guid.NewGuid()
                    };

                return new RespMessage
                {
                    StatusCode = responseMessage.StatusCode,
                    Message = JsonConvert.DeserializeObject<RespMessageTMCS>(content)!.ErrorMsg,
                    Status = StatusMessage.Fail.ToString(),
                    Result = new List<ResInstallmentList>(),
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
            catch (Exception ex)
            {
                return new RespMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Status = StatusMessage.Error.ToString(),
                    Result = new List<ResInstallmentList>(),
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
        }

        public async Task<RespMessage> FetchDataInstallmentDetail(ReqInstallmentDetail reqInstallmentDetail)
        {
            try
            {
                var apiURL = $"/apiInstallment/Appl_Installment";
                var responseMessage = await _connectService.ResponseTMCSContent(apiURL, reqInstallmentDetail);
                var content = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                    return new RespMessage
                    {
                        StatusCode = responseMessage.StatusCode,
                        Message = await _helperService.GetDescription(ContentMessage.Ok),
                        Status = StatusMessage.Success.ToString(),
                        Result = JsonConvert.DeserializeObject<IEnumerable<ResInstallmentDetail>>(content),
                        Timestamp = DateTime.Now,
                        TransactionID = Guid.NewGuid()
                    };

                return new RespMessage
                {
                    StatusCode = responseMessage.StatusCode,
                    Message = JsonConvert.DeserializeObject<RespMessageTMCS>(content)!.ErrorMsg,
                    Status = StatusMessage.Fail.ToString(),
                    Result = new List<ResInstallmentDetail>(),
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
            catch (Exception ex)
            {
                return new RespMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Status = StatusMessage.Error.ToString(),
                    Result = new List<ResInstallmentDetail>(),
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
        }

        public async Task<RespMessage> FetchDataInstallmentQrCode(ReqInstallmentQRCode reqInstallmentQRCode)
        {
            try
            {
                var apiURL = $"/apiInstallment/QRCode_Installment";
                var responseMessage = await _connectService.ResponseTMCSContent(apiURL, reqInstallmentQRCode);
                var content = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                    return new RespMessage
                    {
                        StatusCode = responseMessage.StatusCode,
                        Message = await _helperService.GetDescription(ContentMessage.Ok),
                        Status = StatusMessage.Success.ToString(),
                        Result = JsonConvert.DeserializeObject<IEnumerable<ResInstallmentQRCode>>(content),
                        Timestamp = DateTime.Now,
                        TransactionID = Guid.NewGuid()
                    };

                return new RespMessage
                {
                    StatusCode = responseMessage.StatusCode,
                    Message = JsonConvert.DeserializeObject<RespMessageTMCS>(content)!.ErrorMsg,
                    Status = StatusMessage.Fail.ToString(),
                    Result = new List<ResInstallmentQRCode>(),
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
            catch (Exception ex)
            {
                return new RespMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Status = StatusMessage.Error.ToString(),
                    Result = new List<ResInstallmentQRCode>(),
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
        }
    }
}