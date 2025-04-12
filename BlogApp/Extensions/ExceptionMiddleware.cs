using System.Net;

namespace BlogApp.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // normal akış
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Beklenmeyen bir hata oluştu.");

                // Ek olarak txt dosyasına yaz
                LogHelper.LogToFile($"{ex.Message}\n{ex.StackTrace}");

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "text/html";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = _env.IsDevelopment()
                ? $"<h2>HATA</h2><p>{ex.Message}</p><pre>{ex.StackTrace}</pre>"
                : "<h2>Bir hata oluştu</h2><p>Lütfen daha sonra tekrar deneyin.</p>";

            return context.Response.WriteAsync(message);
        }
    }
}
