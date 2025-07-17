using Microsoft.Extensions.DependencyInjection;
using QuakerLogParse.Application.Interfaces;
using QuakerLogParse.Application.Services;

namespace Infrastructure.Crosscutting
{
    /// <summary>
    /// Classe responsável por registrar as dependências da aplicação para injeção de dependência.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Registra os serviços da aplicação no contêiner de injeção de dependência.
        /// </summary>
        /// <param name="services">A coleção de serviços onde as dependências serão registradas.</param>
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGameAppService, GameAppService>();
            services.AddScoped<ILogParserAppService, LogParserAppService>();
        }
    }
}
