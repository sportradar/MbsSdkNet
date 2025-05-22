using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Probability;

[JsonConverter(typeof(SelectionProbabilityBaseJsonConverter))]
public abstract class SelectionProbabilityBase
{

  public static WinSelectionProbability.Builder NewWinSelectionProbabilityBuilder()
  {
    return WinSelectionProbability.NewBuilder();
  }

  public static PushSelectionProbability.Builder NewPushSelectionProbabilityBuilder()
  {
    return PushSelectionProbability.NewBuilder();
  }
}

public class SelectionProbabilityBaseJsonConverter : JsonConverter<SelectionProbabilityBase>
{

  public override SelectionProbabilityBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using var doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    SelectionProbabilityBase? result = type switch
    {
      "push" => JsonSerializer.Deserialize<PushSelectionProbability>(root.GetRawText()),
      "win" => JsonSerializer.Deserialize<WinSelectionProbability>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of SelectionProbabilityBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null SelectionProbabilityBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, SelectionProbabilityBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }
}
