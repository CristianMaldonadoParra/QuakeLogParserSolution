using QuakerLogParse.Application.DTOs;
using QuakerLogParse.Application.Interfaces;

namespace QuakerLogParse.Application.Services
{
    public class GameAppService : IGameAppService
    {
        private readonly ILogParserAppService _logParserService;

        public GameAppService(ILogParserAppService logParserService)
        {
            _logParserService = logParserService;
        }

        public List<GameDto> GetReports(string logFilePath)
        {
            var games = _logParserService.ParseLog(logFilePath);
            return games.Select(GameDto.FromEntity).ToList();
        }
    }
}
