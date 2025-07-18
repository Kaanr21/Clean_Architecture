using FluentValidation;
using System.Net;
using System.Text.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Hata yakalandı: {Message}", ex.Message);
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = HttpStatusCode.InternalServerError;
        object errors = null;

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                errors = validationException.Errors
                 .Select(e => new
                 {
                     Field = e.PropertyName,
                     Error = string.IsNullOrWhiteSpace(e.ErrorMessage)
                         ? "Geçersiz Alan"
                         : e.ErrorMessage
                 });

                break;

            default:
                errors = new
                {
                    Message = "Sunucuda beklenmeyen bir hata oluştu.",
                    Detail = exception.Message
                };
                break;
        }

        context.Response.StatusCode = (int)statusCode;

        var result = JsonSerializer.Serialize(new
        {
            StatusCode = context.Response.StatusCode,
            Errors = errors
        }, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return context.Response.WriteAsync(result);
    }
}
