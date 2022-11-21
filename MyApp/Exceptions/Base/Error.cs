
using System.Text.Json.Serialization;

namespace MyApp.Base.Exceptions
{
    public class Error
    {
        public Error(string message, string name, int code)
        {
            Message = message;
            Name = name;
            Code = code;
        }

        [JsonPropertyName("message")]
        public string Message { get; }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("code")]
        public int Code { get; }
    }
}
