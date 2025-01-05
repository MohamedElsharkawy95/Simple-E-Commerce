using System.Text.Json.Serialization;

namespace Web.Utilities.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiType
{
    GET,
    POST, 
    PUT,
    DELETE
}
