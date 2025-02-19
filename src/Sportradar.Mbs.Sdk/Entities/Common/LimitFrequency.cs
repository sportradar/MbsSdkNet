using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(LimitFrequencyJsonConverter))]
public enum LimitFrequency {
  MONTHLY,
  DAILY,
  WEEKLY
}

public class LimitFrequencyJsonConverter : JsonConverter<LimitFrequency> {

  public override LimitFrequency Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "monthly" => LimitFrequency.MONTHLY,
      "daily" => LimitFrequency.DAILY,
      "weekly" => LimitFrequency.WEEKLY,
      _ => throw new JsonException("Unknown type of LimitFrequency: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, LimitFrequency value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      LimitFrequency.MONTHLY => "monthly",
      LimitFrequency.DAILY => "daily",
      LimitFrequency.WEEKLY => "weekly",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
