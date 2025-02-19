using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(InitiatorJsonConverter))]
public enum Initiator {
  REGULATOR,
  OTHER,
  OPERATOR,
  PLAYER
}

public class InitiatorJsonConverter : JsonConverter<Initiator> {

  public override Initiator Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "regulator" => Initiator.REGULATOR,
      "other" => Initiator.OTHER,
      "operator" => Initiator.OPERATOR,
      "player" => Initiator.PLAYER,
      _ => throw new JsonException("Unknown type of Initiator: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, Initiator value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      Initiator.REGULATOR => "regulator",
      Initiator.OTHER => "other",
      Initiator.OPERATOR => "operator",
      Initiator.PLAYER => "player",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
