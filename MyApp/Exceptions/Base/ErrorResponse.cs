using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyApp.Base.Exceptions
{
    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public Error Error { get; }

        public ErrorResponse(Error error)
        {
            Error = error;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
