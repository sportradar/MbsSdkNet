using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(OddsChangeJsonConverter))]
public enum OddsChange {
  NONE,
  LOWER,
  HIGHER,
  ANY
}

public class OddsChangeJsonConverter : JsonConverter<OddsChange> {

  public override OddsChange Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "none" => OddsChange.NONE,
      "lower" => OddsChange.LOWER,
      "higher" => OddsChange.HIGHER,
      "any" => OddsChange.ANY,
      _ => throw new JsonException("Unknown type of OddsChange: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, OddsChange value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      OddsChange.NONE => "none",
      OddsChange.LOWER => "lower",
      OddsChange.HIGHER => "higher",
      OddsChange.ANY => "any",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
