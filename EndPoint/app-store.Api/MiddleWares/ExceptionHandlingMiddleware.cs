using Newtonsoft.Json;
using System.Net;

public class ExceptionHandlingMiddleware 
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    public ExceptionHandlingMiddleware(RequestDelegate next,
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
            _logger.LogError($"An unhandled exception has occurred => {ex}");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var result = string.Empty;

        switch (exception)
        {
            case ArgumentException:
                statusCode = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(new { error = exception.Message });
                break;
            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                result = JsonConvert.SerializeObject(new { error = "Resource not found" });
                break;
            default:
                result = JsonConvert.SerializeObject(new { error = "An unexpected error occurred" });
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(result);
    }

}