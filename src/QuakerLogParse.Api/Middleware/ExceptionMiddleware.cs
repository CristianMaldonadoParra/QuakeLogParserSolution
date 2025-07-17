using System.Net;
using System.Text.Json;

namespace QuakerLogParse.Api.Middleware
{
    /// <summary>
    /// Middleware responsável por capturar e tratar exceções não tratadas durante o processamento das requisições HTTP.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ExceptionMiddleware"/>.
        /// </summary>
        /// <param name="next">Delegate para o próximo middleware no pipeline.</param>
        /// <param name="logger">Instância do logger para registrar erros.</param>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Executa o middleware, capturando exceções não tratadas e retornando uma resposta JSON padronizada.
        /// </summary>
        /// <param name="httpContext">O contexto HTTP da requisição.</param>
        /// <returns>Uma tarefa que representa a execução assíncrona do middleware.</returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Manipula a exceção lançada, definindo o status HTTP e retornando uma mensagem de erro em formato JSON.
        /// </summary>
        /// <param name="context">O contexto HTTP da requisição.</param>
        /// <param name="exception">A exceção capturada.</param>
        /// <returns>Uma tarefa que representa a escrita da resposta de erro.</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = new
            {
                Message = "Ocorreu um erro inesperado.",
                Details = exception.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
