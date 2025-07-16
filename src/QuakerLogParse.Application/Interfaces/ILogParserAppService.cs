using QuakerLogParse.Domain.Entities;

namespace QuakerLogParse.Application.Interfaces
{
    public interface ILogParserAppService
    {
        List<Game> ParseLog(string filePath);
    }
}
