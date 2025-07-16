using Microsoft.Extensions.DependencyInjection;
using QuakerLogParse.Application.Interfaces;
using QuakerLogParse.Application.Services;

namespace Infrastructure.Crosscutting
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IGameAppService, GameAppService>();
            services.AddScoped<ILogParserAppService, LogParserAppService>();
        }
    }
}
