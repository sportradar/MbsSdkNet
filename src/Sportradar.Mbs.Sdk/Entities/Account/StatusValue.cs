using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Account;

[JsonConverter(typeof(StatusValueJsonConverter))]
public enum StatusValue
{
    ACTIVE,
    DISABLED,
    EXCLUDED
}

public class StatusValueJsonConverter : JsonConverter<StatusValue>
{
    public override StatusValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonVal = reader.GetString();
        return jsonVal switch
        {
            "active" => StatusValue.ACTIVE,
            "disabled" => StatusValue.DISABLED,
            "excluded" => StatusValue.EXCLUDED,
            _ => throw new JsonException("Unknown type of StatusValue: " + jsonVal)
        };
    }

    public override void Write(Utf8JsonWriter writer, StatusValue value, JsonSerializerOptions options)
    {
        var jsonVal = value switch
        {
            StatusValue.ACTIVE => "active",
            StatusValue.DISABLED => "disabled",
            StatusValue.EXCLUDED => "excluded",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
        writer.WriteStringValue(jsonVal);
    }
}