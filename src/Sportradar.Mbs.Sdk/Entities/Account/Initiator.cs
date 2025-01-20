using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Account;

[JsonConverter(typeof(InitiatorJsonConverter))]
public enum Initiator
{
    PLAYER,
    OPERATOR,
    REGULATOR,
    OTHER
}

public class InitiatorJsonConverter : JsonConverter<Initiator>
{
    public override Initiator Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonVal = reader.GetString();
        return jsonVal switch
        {
            "player" => Initiator.PLAYER,
            "operator" => Initiator.OPERATOR,
            "regulator" => Initiator.REGULATOR,
            "other" => Initiator.OTHER,
            _ => throw new JsonException("Unknown type of Initiator: " + jsonVal)
        };
    }

    public override void Write(Utf8JsonWriter writer, Initiator value, JsonSerializerOptions options)
    {
        var jsonVal = value switch
        {
            Initiator.PLAYER => "player",
            Initiator.OPERATOR => "operator",
            Initiator.REGULATOR => "regulator",
            Initiator.OTHER => "other",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
        writer.WriteStringValue(jsonVal);
    }
}