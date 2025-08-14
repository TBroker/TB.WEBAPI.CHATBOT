using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Requests;

namespace TB.Chatbot.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/tracking/")]
    [ApiController]
    public class TrackingController(ITrackingService trackingService) : Controller
    {
        private readonly ITrackingService _trackingService = trackingService;

        [HttpPost("fetch/thaipost")]
        public async Task<IActionResult> GetDataThaiPostTracking(ReqDataTracking reqDataTracking)
        {
            return Ok(await _trackingService.GetDataThaiPostTracking(reqDataTracking));
        }
    }
}