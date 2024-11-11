using api.Domain.ValueObjects;
using System.Text.Json;
using System.Text.Json.Serialization;

public class PaymentMethodConverter : JsonConverter<PaymentMethod>
{
    public override PaymentMethod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException("Expected StartObject token");

        reader.Read();

        if (reader.TokenType != JsonTokenType.PropertyName || reader.GetString() != "method")
            throw new JsonException("Expected 'method' property");

        reader.Read();

        var method = reader.GetString();

        reader.Read();

        return new PaymentMethod(method);
    }

    public override void Write(Utf8JsonWriter writer, PaymentMethod value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("method", value.Method);
        writer.WriteEndObject();
    }
}
