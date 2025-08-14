using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Requests;

namespace TB.Chatbot.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [ApiController]
    public class WebDataController(IWebDataService webDataService) : Controller
    {
        private readonly IWebDataService _webDataService = webDataService;

        #region ######### Master #########

        [HttpPost("api/master/carbrand")]
        public async Task<IActionResult> GetCarBrand()
        {
            return Ok(await _webDataService.GetDataCarBrand());
        }

        [HttpPost("api/master/carmodel")]
        public async Task<IActionResult> GetCarModel([FromBody] ReqCarModel reqCarModel)
        {
            return Ok(await _webDataService.GetDataCarModel(reqCarModel));
        }

        [HttpPost("api/master/cardetail")]
        public async Task<IActionResult> GetCarDetail([FromBody] ReqCarDetail reqCarDetail)
        {
            return Ok(await _webDataService.GetDataCarDetail(reqCarDetail));
        }

        [HttpPost("api/master/carenginesize")]
        public async Task<IActionResult> GetCarEngineSize([FromBody] ReqCarEngineSize reqCarEngineSize)
        {
            return Ok(await _webDataService.GetDataCarEngineSize(reqCarEngineSize));
        }

        [HttpPost("api/master/caryear")]
        public async Task<IActionResult> GetCarYear([FromBody] ReqCarYear reqCarYear)
        {
            return Ok(await _webDataService.GetDataCarYear(reqCarYear));
        }

        [HttpPost("api/master/coveragetype")]
        public async Task<IActionResult> GetCoverageType()
        {
            return Ok(await _webDataService.GetDataCoverageType());
        }

        [HttpPost("api/master/company")]
        public async Task<IActionResult> GetDataCompany()
        {
            return Ok(await _webDataService.GetDataCompany());
        }

        [HttpPost("api/master/product")]
        public async Task<IActionResult> GetDataProduct([FromBody] ReqProduct reqProduct)
        {
            return Ok(await _webDataService.GetDataProduct(reqProduct));
        }

        [HttpPost("api/master/automobile")]
        public async Task<IActionResult> GetDataAutoMobile()
        {
            return Ok(await _webDataService.GetDataAutoMobile());
        }

        [HttpPost("api/master/filtercomm")]
        public async Task<IActionResult> GetDataFilterComm()
        {
            return Ok(await _webDataService.GetDataFilterComm());
        }

        #endregion ######### Master #########

        #region ######### Data #########

        [HttpPost("api/data/premiumslist")]
        public async Task<IActionResult> GetDataPremiumsList([FromBody] ReqPremiumList reqPremiumList)
        {
            return Ok(await _webDataService.GetDataPremiumsList(reqPremiumList));
        }

        [HttpPost("api/data/premiums")]
        public async Task<IActionResult> GetDataPremiums([FromBody] ReqPremium reqPremium)
        {
            return Ok(await _webDataService.GetDataPremiums(reqPremium));
        }

        [HttpPost("api/data/user")]
        public async Task<IActionResult> GetDataUser([FromBody] ReqUser reqUser)
        {
            return Ok(await _webDataService.GetDataUser(reqUser));
        }

        [HttpPost("api/data/calcommission")]
        public async Task<IActionResult> CalculationPremium([FromBody] ReqCalComm reqCalComm)
        {
            return Ok(await _webDataService.CalculationPremium(reqCalComm));
        }

        [HttpPost("api/data/tracking")]
        public async Task<IActionResult> GetDataTracking([FromBody] ReqDataTracking reqDataTracking)
        {
            return Ok(await _webDataService.GetDataTracking(reqDataTracking));
        }

        [HttpPost("api/data/reward")]
        public async Task<IActionResult> GetRewardPoint([FromBody] ReqUser reqUser)
        {
            return Ok(await _webDataService.GetRewardPoint(reqUser));
        }

        #endregion ######### Data #########

        #region ######### Command #########

        [HttpPost("api/command/ordermotor")]
        public async Task<IActionResult> InsertDataOrderMotor([FromBody] ReqOrderMotor reqOrderMotor)
        {
            return Ok(await _webDataService.InsertQuotations(reqOrderMotor));
        }

        #endregion ######### Command #########
    }
}