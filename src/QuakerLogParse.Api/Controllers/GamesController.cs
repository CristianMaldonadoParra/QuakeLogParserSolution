using Microsoft.AspNetCore.Mvc;
using QuakerLogParse.Application.Interfaces;

namespace QuakerLogParse.Api.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameAppService _appService;

        public GamesController(IGameAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("parse-log")]
        public IActionResult ParseLog([FromQuery] string logFilePath)
        {
            var reports = _appService.GetReports(logFilePath);
            return Ok(reports);
        }
    }
}
