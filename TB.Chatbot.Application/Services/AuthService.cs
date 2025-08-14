using Newtonsoft.Json;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Reponses;

namespace TB.Chatbot.Application.Services
{
    public class AuthService(IConnectService connectService) : IAuthService
    {
        private readonly IConnectService _connectService = connectService;

        public async Task<string> GetThaiPostToken()
        {
            try
            {
                var apiURL = $"/post/api/v1/authenticate/token";
                var responseMessage = await _connectService.ResponseThaiPostContent(apiURL, new { });
                var content = await responseMessage.Content.ReadAsStringAsync();

                if (responseMessage.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<RespThaiPostToken>(content)!.token!;

                return new RespThaiPostToken().token!;
            }
            catch
            {
                return new RespThaiPostToken().token!;
            }
        }
    }
}