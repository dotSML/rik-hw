using System.Text.Json.Serialization;

namespace api.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AttendeeType
    {
        NaturalPerson,
        LegalEntity
    }
}