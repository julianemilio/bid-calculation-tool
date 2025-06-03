using Domain.Vehicles.Exeptions;
using System.Net;
using System.Text.Json;

namespace WebApi.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "An unexpected error occurred");

        var statusCode = exception switch
        {
            InvalidPriceException => HttpStatusCode.BadRequest,
            _ => HttpStatusCode.InternalServerError
        };

        var result = JsonSerializer.Serialize(new
        {
            error = exception.Message,
            stackTrace = context.RequestServices.GetRequiredService<IWebHostEnvironment>().IsDevelopment()
                ? exception.StackTrace
                : null
        });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(result);
    }
}