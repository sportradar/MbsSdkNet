using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Stake;

[JsonConverter(typeof(StakeModeJsonConverter))]
public enum StakeMode {
  UNIT,
  TOTAL
}

public class StakeModeJsonConverter : JsonConverter<StakeMode> {

  public override StakeMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "unit" => StakeMode.UNIT,
      "total" => StakeMode.TOTAL,
      _ => throw new JsonException("Unknown type of StakeMode: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, StakeMode value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      StakeMode.UNIT => "unit",
      StakeMode.TOTAL => "total",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
