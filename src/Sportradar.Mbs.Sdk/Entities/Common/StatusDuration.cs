using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(StatusDurationJsonConverter))]
public enum StatusDuration {
  TEMPORARY,
  PERMANENT
}

public class StatusDurationJsonConverter : JsonConverter<StatusDuration> {

  public override StatusDuration Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "temporary" => StatusDuration.TEMPORARY,
      "permanent" => StatusDuration.PERMANENT,
      _ => throw new JsonException("Unknown type of StatusDuration: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, StatusDuration value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      StatusDuration.TEMPORARY => "temporary",
      StatusDuration.PERMANENT => "permanent",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
