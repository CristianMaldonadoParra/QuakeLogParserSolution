using QuakerLogParse.Application.DTOs;

namespace QuakerLogParse.Application.Interfaces
{
    public interface IGameAppService
    {
        List<GameDto> GetReports(string logFilePath);
    }
}
