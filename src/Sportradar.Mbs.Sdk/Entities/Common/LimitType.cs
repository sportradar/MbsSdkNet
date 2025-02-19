using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(LimitTypeJsonConverter))]
public enum LimitType {
  DEPOSIT,
  SESSION,
  LOSS,
  STAKE
}

public class LimitTypeJsonConverter : JsonConverter<LimitType> {

  public override LimitType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "deposit" => LimitType.DEPOSIT,
      "session" => LimitType.SESSION,
      "loss" => LimitType.LOSS,
      "stake" => LimitType.STAKE,
      _ => throw new JsonException("Unknown type of LimitType: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, LimitType value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      LimitType.DEPOSIT => "deposit",
      LimitType.SESSION => "session",
      LimitType.LOSS => "loss",
      LimitType.STAKE => "stake",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
