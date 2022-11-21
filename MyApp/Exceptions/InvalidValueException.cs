using MyApp.Base.Exceptions;
using System.Net;

namespace MyApp.Exceptions
{
    public class InvalidValueException : ApiException
    {
        public InvalidValueException(string propertyName) :
            base(ApiErrorCode.InvalidValue, propertyName)
        { }
        
        protected override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
