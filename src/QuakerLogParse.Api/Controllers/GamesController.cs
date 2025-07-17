using Microsoft.AspNetCore.Mvc;
using QuakerLogParse.Application.Interfaces;

namespace QuakerLogParse.Api.Controllers
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="GamesController"/>.
    /// Configura o serviço de aplicação de jogos e obtém o caminho do arquivo de log a partir da configuração.
    /// </summary>
    /// <param name="appService">Serviço de aplicação utilizado para processar os relatórios de jogos.</param>
    /// <param name="configuration">Configuração da aplicação, utilizada para obter o caminho do arquivo de log.</param>
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

        /// <summary>
        /// Realiza o parsing do arquivo de log do Quake e retorna um relatório de todos os jogos encontrados.
        /// </summary>
        /// <returns>
        /// Um <see cref="IActionResult"/> contendo a lista de relatórios dos jogos.
        /// </returns>
        [HttpGet("parse-log")]
        public IActionResult ParseLog()
        {
            var reports = _appService.GetReports(_logFilePath);
            return Ok(reports);
        }
    }
}
