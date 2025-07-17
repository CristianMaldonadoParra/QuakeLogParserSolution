using QuakerLogParse.Application.DTOs;
using QuakerLogParse.Application.Interfaces;

namespace QuakerLogParse.Application.Services
{
    // <summary>
    /// Serviço de aplicação responsável por obter relatórios dos jogos a partir do arquivo de log.
    /// </summary>
    public class GameAppService : IGameAppService
    {
        private readonly ILogParserAppService _logParserService;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="GameAppService"/>.
        /// </summary>
        /// <param name="logParserService">Serviço responsável por fazer o parsing do arquivo de log.</param>
        public GameAppService(ILogParserAppService logParserService)
        {
            _logParserService = logParserService;
        }

        /// <summary>
        /// Obtém a lista de relatórios dos jogos a partir do arquivo de log informado.
        /// </summary>
        /// <param name="logFilePath">Caminho do arquivo de log do Quake.</param>
        /// <returns>Lista de objetos <see cref="GameDto"/> representando os jogos encontrados no log.</returns>
        public List<GameDto> GetReports(string logFilePath)
        {
            var games = _logParserService.ParseLog(logFilePath);
            return games.Select(GameDto.FromEntity).ToList();
        }
    }
}
