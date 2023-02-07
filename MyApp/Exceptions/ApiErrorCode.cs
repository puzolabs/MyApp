namespace MyApp.Exceptions
{
    public enum ApiErrorCode
    {
        InternalServerError = 500,

        //BadRequest
        MissingValue = 5001,
        InvalidValue = 5002,
        MultipleUserRolesInSameDomainError = 5003,
        
        // NotFound
        NotFound = 5100,

        //Conflict
        AlreadyExists = 5200,
        InvalidUsernameOrPassword = 5201,
        UserHasNoDomains = 5202,

        Unauthorized = 5300,
    }
}
