using MyApp.Base.Exceptions;
using System.Net;

namespace MyApp.Exceptions
{
    public class GeneralBadRequestException : ApiException
    {
        public GeneralBadRequestException(ApiErrorCode errorCode, params object[] messageParams) : base(errorCode, messageParams)
        {
        }

        protected override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
