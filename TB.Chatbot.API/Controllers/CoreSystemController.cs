using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Requests;

namespace TB.Chatbot.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/core/")]
    [ApiController]
    public class CoreSystemController(ICoreSystemService coreSystemService) : ControllerBase
    {
        private readonly ICoreSystemService _coreSystemService = coreSystemService;

        [HttpPost("fetch/agent")]
        public async Task<IActionResult> GetAgent([FromBody] ReqAgent reqAgent)
        {
            return Ok(await _coreSystemService.GetAgent(reqAgent));
        }

        [HttpPost("fetch/installment")]
        public async Task<IActionResult> FetchDataInstallment([FromBody] ReqInstallmentList reqInstallmentList)
        {
            return Ok(await _coreSystemService.FetchDataInstallment(reqInstallmentList));
        }

        [HttpPost("fetch/installment/detail")]
        public async Task<IActionResult> FetchDataInstallmentDetail([FromBody] ReqInstallmentDetail reqInstallmentDetail)
        {
            return Ok(await _coreSystemService.FetchDataInstallmentDetail(reqInstallmentDetail));
        }

        [HttpPost("fetch/installment/qrcode")]
        public async Task<IActionResult> FetchDataInstallmentQrCode([FromBody] ReqInstallmentQRCode reqInstallmentQRCode)
        {
            return Ok(await _coreSystemService.FetchDataInstallmentQrCode(reqInstallmentQRCode));
        }
    }
}
