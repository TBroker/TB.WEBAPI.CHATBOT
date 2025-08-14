using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Settings;

namespace TB.Chatbot.Application.Services
{
    public class AuthConnectService(IOptions<ThaiPostSetting> thaiPostSetting, IAuthService authService) : IAuthConnectService
    {
        private readonly ThaiPostSetting _thaiPostSetting = thaiPostSetting.Value;
        private readonly IAuthService _authService = authService;

        public async Task<HttpResponseMessage> ResponseAuthThaiPostContent(string _url, object _dataJson)
        {
            try
            {
                // สร้าง HttpClientHandler
                var handler = new HttpClientHandler
                {
                    // ปิดการให้ใช้งาน JavaScript (Fetch/XHR)
                    UseDefaultCredentials = true
                };

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri($"{_thaiPostSetting.Url}")
                };

                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", await _authService.GetThaiPostToken());

                return await httpClient.PostAsJsonAsync(_url, _dataJson);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError); ;
            }
        }
    }
}