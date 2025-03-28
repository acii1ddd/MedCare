using System.Net;
using System.Text.Json;
using MedCare.BLL.Exceptions;

namespace MedCare.API.Middleware;

public class ExceptionHandling
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandling> _logger;

    public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var (statusCode, errorMessage) = ex switch
            {
                InvalidOperationException operationEx => (HttpStatusCode.BadRequest, operationEx.Message),
                NotFoundException notFoundEx => (HttpStatusCode.NotFound, notFoundEx.Message),
                UnauthorizedAccessException unauthorizedEx => (HttpStatusCode.Unauthorized, unauthorizedEx.Message),
                NotImplementedException notImpEx => (HttpStatusCode.NotImplemented, notImpEx.Message),
                _ => (HttpStatusCode.InternalServerError, "Необработанная ошибка сервера: " + ex.Message)
            };
            
            context.Response.StatusCode = (int) statusCode;
            context.Response.ContentType = "application/json";

            var response = new
            {
                ErrorMessage = errorMessage,
                Trace = ex.StackTrace
            };
            _logger.LogError(ex, "Произошла ошибка при работе приложения: {errorMessage}", errorMessage);
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}