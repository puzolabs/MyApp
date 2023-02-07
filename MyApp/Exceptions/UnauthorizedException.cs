using MyApp.Base.Exceptions;
using System.Net;

namespace MyApp.Exceptions
{
    public class UnauthorizedException : ApiException
    {
        public UnauthorizedException(string entityType, object entityIdentifier = null) :
            base(ApiErrorCode.Unauthorized, entityType, entityIdentifier)
        { }

        protected override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    }
}
