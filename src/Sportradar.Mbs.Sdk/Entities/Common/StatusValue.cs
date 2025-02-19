using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(StatusValueJsonConverter))]
public enum StatusValue {
  DISABLED,
  EXCLUDED,
  ACTIVE
}

public class StatusValueJsonConverter : JsonConverter<StatusValue> {

  public override StatusValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "disabled" => StatusValue.DISABLED,
      "excluded" => StatusValue.EXCLUDED,
      "active" => StatusValue.ACTIVE,
      _ => throw new JsonException("Unknown type of StatusValue: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, StatusValue value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      StatusValue.DISABLED => "disabled",
      StatusValue.EXCLUDED => "excluded",
      StatusValue.ACTIVE => "active",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
