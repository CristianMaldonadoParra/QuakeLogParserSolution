using Microsoft.AspNetCore.Mvc;
using QuakerLogParse.Application.Interfaces;

namespace QuakerLogParse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly string _logFilePath;
        private readonly IGameAppService _appService;

        public GamesController(IGameAppService appService, IConfiguration configuration)
        {
            _appService = appService;
            _logFilePath = configuration["LogFilePath"] ?? "";
        }

        [HttpGet("parse-log")]
        public IActionResult ParseLog()
        {
            var reports = _appService.GetReports(_logFilePath);
            return Ok(reports);
        }
    }
}
