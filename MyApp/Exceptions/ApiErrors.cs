using System.Collections.Generic;

namespace MyApp.Exceptions
{
    public static class ApiErrors
    {
        private static readonly Dictionary<ApiErrorCode, string> ErrorCodeToMessageMap = new Dictionary<ApiErrorCode, string>()
        {
            { ApiErrorCode.InternalServerError, "Could not complete the request because of an internal error" },

            { ApiErrorCode.NotFound, "{0} '{1}' was not found" },
            { ApiErrorCode.AlreadyExists, "{0} already exists" },
            { ApiErrorCode.MissingValue, "'{0}' is required" },
            { ApiErrorCode.InvalidValue, "'{0}': invalid value" },
            { ApiErrorCode.Unauthorized, "unauthorized access" },
        };
        
        public static IReadOnlyDictionary<ApiErrorCode, string> Map => ErrorCodeToMessageMap;
    }
}
