namespace QuakerLogParse.Api.Configuration
{
    /// <summary>
    /// Classe responsável pela configuração inicial da API, incluindo configuração de arquivos e serviços.
    /// </summary>
    public static class ApiConfig
    {
        /// <summary>
        /// Adiciona as configurações padrão da API ao <see cref="WebApplicationBuilder"/>, 
        /// incluindo arquivos de configuração, variáveis de ambiente e registro dos controllers.
        /// </summary>
        /// <param name="builder">Instância do <see cref="WebApplicationBuilder"/> a ser configurada.</param>
        /// <returns>O próprio <see cref="WebApplicationBuilder"/> para encadeamento de chamadas.</returns>
        /// <exception cref="ArgumentNullException">Lançada se o parâmetro <paramref name="builder"/> for nulo.</exception>s
        public static WebApplicationBuilder AddApiConfiguration(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Configuration
                        .SetBasePath(builder.Environment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables();

            builder.Services.AddControllers();

            return builder;
        }
    }
}
