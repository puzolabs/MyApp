using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MyApp.Base.Exceptions
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionsMiddleware> _logger;

        public ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger)
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
            catch (ApiException exception)
            {
                _logger.LogError(exception, "Api exception error occurred");

                await exception.HandleException(httpContext);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unexpected error occurred: ");

                await HandleUnexpectedExceptionAsync(httpContext);
            }
        }

        private static Task HandleUnexpectedExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ErrorResponse errorResponse = new ErrorResponse(
                new Error("Unhandled Exception Occurred", HttpStatusCode.InternalServerError.ToString(), context.Response.StatusCode));

            return context.Response.WriteAsync(errorResponse.ToString());
        }
    }
}
