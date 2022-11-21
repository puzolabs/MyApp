using MyApp.Base.Exceptions;
using System.Net;

namespace MyApp.Exceptions
{
    public class AlreadyExistsException : ApiException
    {
        public AlreadyExistsException(string entity) : 
            base(ApiErrorCode.AlreadyExists, entity) { }

        protected override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    }
}
