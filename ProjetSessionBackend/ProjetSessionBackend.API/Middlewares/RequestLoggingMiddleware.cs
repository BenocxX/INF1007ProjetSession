namespace ProjetSessionBackend.API.Middlewares;

using System.Diagnostics;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var startTime = Stopwatch.GetTimestamp();

        try
        {
            await _next(context);
        }
        finally
        {
            var endTime = Stopwatch.GetTimestamp();
            var duration = TimeSpan.FromTicks((endTime - startTime) * TimeSpan.TicksPerSecond / Stopwatch.Frequency);
            _logger.LogInformation("{RequestMethod} {RequestPath} took {DurationTotalMilliseconds} ms", context.Request.Method, context.Request.Path, duration.TotalMilliseconds);
        }
    }
}