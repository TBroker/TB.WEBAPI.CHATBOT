using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Settings;

namespace TB.Chatbot.Application.Services
{
    public class ConnectService(IOptions<CoreSystemSetting> coreSystemSetting, IOptions<ThaiPostSetting> thaiPostSetting) : IConnectService
    {
        private readonly CoreSystemSetting _coreSystemSettings = coreSystemSetting.Value;
        private readonly ThaiPostSetting _thaiPostSetting = thaiPostSetting.Value;

        public async Task<HttpResponseMessage> ResponseTMCSContent(string _url, object _dataJson)
        {
            var userName = $"{_coreSystemSettings.UserNameTMCS}";
            var userPassword = $"{_coreSystemSettings.PasswordTMCS}";

            // สร้าง HttpClientHandler
            var handler = new HttpClientHandler
            {
                // ปิดการให้ใช้งาน JavaScript (Fetch/XHR)
                UseDefaultCredentials = true
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri($"{_coreSystemSettings.UrlTMCS}")
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userName}:{userPassword}")));
            httpClient.DefaultRequestHeaders.Add("API_KEY", $"{_coreSystemSettings.KeyTMCS}");

            return await httpClient.PostAsJsonAsync(_url, _dataJson);
        }

        public async Task<HttpResponseMessage> ResponseThaiPostContent(string _url, object _dataJson)
        {
            // สร้าง HttpClientHandler
            var handler = new HttpClientHandler
            {
                // ปิดการให้ใช้งาน JavaScript (Fetch/XHR)
                UseDefaultCredentials = true
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri($"{_thaiPostSetting.Url}")
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", _thaiPostSetting.Token);

            return await httpClient.PostAsJsonAsync(_url, _dataJson);
        }
    }
}