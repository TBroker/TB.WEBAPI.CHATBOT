using Newtonsoft.Json;
using System.Net;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Entities;
using TB.Chatbot.Domain.Enums;
using TB.Chatbot.Domain.Reponses;
using TB.Chatbot.Domain.Requests;
using static TB.Chatbot.Domain.Reponses.RespThaiPostTracking;
using static TB.Chatbot.Domain.Reponses.RespTracking;

namespace TB.Chatbot.Application.Services
{
    public class TrackingService(IAuthConnectService authConnectService, IHelperService helperService, IWebDataService webDataService) : ITrackingService
    {
        private readonly IAuthConnectService _authConnectService = authConnectService;
        private readonly IWebDataService _webDataService = webDataService;
        private readonly IHelperService _helperService = helperService;

        public async Task<RespMessage> ThaiPostTracking(ReqThaiPostTracking reqThaiPostTracking)
        {
            try
            {
                var apiURL = $"/post/api/v1/track";
                var responseMessage = await _authConnectService.ResponseAuthThaiPostContent(apiURL, reqThaiPostTracking);
                var content = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                    return new RespMessage
                    {
                        StatusCode = responseMessage.StatusCode,
                        Message = await _helperService.GetDescription(ContentMessage.Ok),
                        Status = StatusMessage.Success.ToString(),
                        Result = JsonConvert.DeserializeObject<RespThaiPostTracking>(content)!.response!.items,
                        Timestamp = DateTime.Now,
                        TransactionID = Guid.NewGuid()
                    };

                return new RespMessage
                {
                    StatusCode = responseMessage.StatusCode,
                    Message = await _helperService.GetDescription(ContentMessage.NoContent),
                    Status = StatusMessage.Fail.ToString(),
                    Result = JsonConvert.DeserializeObject<RespThaiPostTracking>(content)!.response!.items,
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
                    Result = new { },
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
        }

        public async Task<RespMessage> GetDataThaiPostTracking(ReqDataTracking reqDataTracking)
        {
            try
            {
                var lsTracking = new List<RespTracking>();

                var dataTracking = await _webDataService.GetDataTracking(reqDataTracking);
                var objResults = JsonConvert.DeserializeObject<RespMessage>(JsonConvert.SerializeObject(dataTracking))!.Result;
                var lsDataTracking = JsonConvert.DeserializeObject<IEnumerable<WebDataTracking>>(JsonConvert.SerializeObject(objResults))!;

                if (!lsDataTracking.Any())
                    return new RespMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = await _helperService.GetDescription(ContentMessage.NoContent),
                        Status = StatusMessage.Success.ToString(),
                        Result = lsTracking,
                        Timestamp = DateTime.Now,
                        TransactionID = Guid.NewGuid()
                    };

                var lsBarCode = new List<string>();

                foreach (var data in lsDataTracking)
                {
                    lsBarCode.Add(data.TrackingNo!);
                }

                var reqThaiPostTracking = new ReqThaiPostTracking()
                {
                    status = "all",
                    language = "TH",
                    barcode = lsBarCode,
                };

                var dataThaiPostTracking = await ThaiPostTracking(reqThaiPostTracking);
                var objResults2 = JsonConvert.DeserializeObject<RespMessage>(JsonConvert.SerializeObject(dataThaiPostTracking))!.Result;
                var dicItemData = JsonConvert.DeserializeObject<Dictionary<string, List<ItemData>>>(JsonConvert.SerializeObject(objResults2))!;

                foreach (var data in lsDataTracking)
                {
                    var detail = new Detail
                    {
                        DetailTracking = dicItemData.Where(x => x.Key.Equals(data.TrackingNo)).FirstOrDefault().Value
                    };

                    lsTracking.Add(
                        new RespTracking()
                        {
                            NameInsurance = lsDataTracking.FirstOrDefault(x => x.NameInsurance! == data.NameInsurance)!.NameInsurance,
                            CarRegistration = lsDataTracking.FirstOrDefault(x => x.CarRegistration! == data.CarRegistration)!.CarRegistration,
                            Items = detail,
                        });
                }

                return new RespMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = await _helperService.GetDescription(ContentMessage.Ok),
                    Status = StatusMessage.Success.ToString(),
                    Result = lsTracking,
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
                    Result = new List<RespTracking> { },
                    Timestamp = DateTime.Now,
                    TransactionID = Guid.NewGuid()
                };
            }
        }
    }
}