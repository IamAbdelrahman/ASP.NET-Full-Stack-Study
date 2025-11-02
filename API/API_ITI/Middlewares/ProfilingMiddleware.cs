using System.Diagnostics;

namespace Demos.Middlewares
{
    public class ProfilingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfilingMiddleware> _logger;
        public ProfilingMiddleware(RequestDelegate next, ILogger<ProfilingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            await _next(context);
            stopwatch.Stop();
            _logger.LogInformation($"Request [{context.Request.Path}]executed in {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
