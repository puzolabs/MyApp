using MyApp.Base.Exceptions;
using System.Net;

namespace MyApp.Exceptions
{
    public class MissingValueException : ApiException
    {
        public MissingValueException(string entityType, object entityIdentifier = null) :
            base(ApiErrorCode.MissingValue, entityType, entityIdentifier)
        { }

        protected override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
