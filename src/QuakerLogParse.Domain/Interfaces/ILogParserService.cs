using QuakerLogParse.Domain.Entities;

namespace QuakerLogParse.Domain.Interfaces
{
    public interface ILogParserService
    {
        Task<List<Game>> ParseLogAsync(string filePath);
    }
}
