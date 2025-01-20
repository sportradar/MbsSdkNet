using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Account;

[JsonConverter(typeof(LimitTypeJsonConverter))]
public enum LimitType
{
    DEPOSIT,
    BET,
    LOSS,
    SESSION
}

public class LimitTypeJsonConverter : JsonConverter<LimitType>
{
    public override LimitType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonVal = reader.GetString();
        return jsonVal switch
        {
            "deposit" => LimitType.DEPOSIT,
            "bet" => LimitType.BET,
            "loss" => LimitType.LOSS,
            "session" => LimitType.SESSION,
            _ => throw new JsonException("Unknown type of LimitType: " + jsonVal)
        };
    }

    public override void Write(Utf8JsonWriter writer, LimitType value, JsonSerializerOptions options)
    {
        var jsonVal = value switch
        {
            LimitType.DEPOSIT => "deposit",
            LimitType.BET => "bet",
            LimitType.LOSS => "loss",
            LimitType.SESSION => "session",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
        writer.WriteStringValue(jsonVal);
    }
}