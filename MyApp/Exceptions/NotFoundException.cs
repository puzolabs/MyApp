using MyApp.Base.Exceptions;
using System.Net;

namespace MyApp.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string entityType, object entityIdentifier = null) :
            base(ApiErrorCode.NotFound, entityType, entityIdentifier)
        { }

        protected override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    }
}
