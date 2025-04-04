using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(AcceptanceStatusJsonConverter))]
public enum AcceptanceStatus {
  ACCEPTED,
  REJECTED
}

public class AcceptanceStatusJsonConverter : JsonConverter<AcceptanceStatus> {

  public override AcceptanceStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "accepted" => AcceptanceStatus.ACCEPTED,
      "rejected" => AcceptanceStatus.REJECTED,
      _ => throw new JsonException("Unknown type of AcceptanceStatus: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, AcceptanceStatus value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      AcceptanceStatus.ACCEPTED => "accepted",
      AcceptanceStatus.REJECTED => "rejected",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
