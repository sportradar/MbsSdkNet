using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Account;

[JsonConverter(typeof(LimitFrequencyJsonConverter))]
public enum LimitFrequency
{
    DAILY,
    WEEKLY,
    MONTHLY
}

public class LimitFrequencyJsonConverter : JsonConverter<LimitFrequency>
{
    public override LimitFrequency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonVal = reader.GetString();
        return jsonVal switch
        {
            "daily" => LimitFrequency.DAILY,
            "weekly" => LimitFrequency.WEEKLY,
            "monthly" => LimitFrequency.MONTHLY,
            _ => throw new JsonException("Unknown type of LimitFrequency: " + jsonVal)
        };
    }

    public override void Write(Utf8JsonWriter writer, LimitFrequency value, JsonSerializerOptions options)
    {
        var jsonVal = value switch
        {
            LimitFrequency.DAILY => "daily",
            LimitFrequency.WEEKLY => "weekly",
            LimitFrequency.MONTHLY => "monthly",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
        writer.WriteStringValue(jsonVal);
    }
}