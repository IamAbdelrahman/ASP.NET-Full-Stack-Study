namespace Demos.Middlewares
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static int _count = 0;
        private static DateTime _lastRequestDate = DateTime.Now; 
        public RateLimitingMiddleware(RequestDelegate next)
        {
            _next=next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _count++;
            if (DateTime.Now.Subtract(_lastRequestDate).TotalSeconds > 10)
            {
                _count = 1;
                _lastRequestDate = DateTime.Now;
                await _next(context);
            }
            else
                {
                if (_count <= 5)
                {
                    _lastRequestDate = DateTime.Now;
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = 429; // Too Many Requests
                    await context.Response.WriteAsync("Rate limit exceeded. Try again later.");
                }
            }
        }
    }
}
