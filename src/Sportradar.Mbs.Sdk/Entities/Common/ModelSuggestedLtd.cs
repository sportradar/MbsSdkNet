using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(ModelSuggestedLtdJsonConverter))]
public enum ModelSuggestedLtd {
  NONE,
  SKIP,
  DELAY
}

public class ModelSuggestedLtdJsonConverter : JsonConverter<ModelSuggestedLtd> {

  public override ModelSuggestedLtd Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "None" => ModelSuggestedLtd.NONE,
      "Skip" => ModelSuggestedLtd.SKIP,
      "Delay" => ModelSuggestedLtd.DELAY,
      _ => throw new JsonException("Unknown type of ModelSuggestedLtd: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, ModelSuggestedLtd value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      ModelSuggestedLtd.NONE => "None",
      ModelSuggestedLtd.SKIP => "Skip",
      ModelSuggestedLtd.DELAY => "Delay",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
