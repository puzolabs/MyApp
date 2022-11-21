using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyApp.Exceptions;

namespace MyApp.Base.Exceptions
{
    public abstract class ApiException : System.Exception
    {
        private readonly ApiErrorCode _apiErrorCode;
        private readonly object[] _messageParams;

        protected abstract HttpStatusCode StatusCode { get; }

        protected ApiException(ApiErrorCode errorCode, params object[] messageParams)
            : base(GetErrorMessage(errorCode, messageParams))
        {
            _apiErrorCode = errorCode;
            _messageParams = messageParams;
        }

        public Task HandleException(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)StatusCode;

            ErrorResponse errorResponse = new ErrorResponse(
                new Error(GetErrorMessage(_apiErrorCode, _messageParams),
                    _apiErrorCode.ToString(),
                    (int)_apiErrorCode));

            return context.Response.WriteAsync(errorResponse.ToString());
        }

        public static string GetErrorMessage(ApiErrorCode errorCode, params object[] messageParams)
        {
            return string.Format(ApiErrors.Map[errorCode], messageParams);
        }
    }
}