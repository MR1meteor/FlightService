using FlightService.Core.Exceptions;
using System.Net;

namespace FlightService.Api.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        public readonly ILogger<CustomExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(
            ILogger<CustomExceptionHandlerMiddleware> logger,
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (ApiException ex)
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = (int)ex.StatusCode;
                _logger.LogWarning(ex.ApiMessage);
                await context.Response.WriteAsync(ex.ApiMessage);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync($"Something went wrong: {ex.Message}");
                _logger.LogError(ex, ex.Message);
            }
        }
    }
}
