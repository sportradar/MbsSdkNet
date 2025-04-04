using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Selection;

[JsonConverter(typeof(SelectionBaseJsonConverter))]
public abstract class SelectionBase
{

  public static UfSelection.Builder NewUfSelectionBuilder()
  {
    return UfSelection.NewBuilder();
  }

  public static ExtSelection.Builder NewExtSelectionBuilder()
  {
    return ExtSelection.NewBuilder();
  }

  public static OddsBoostSelection.Builder NewOddsBoostSelectionBuilder()
  {
    return OddsBoostSelection.NewBuilder();
  }

  public static WaysSelection.Builder NewWaysSelectionBuilder()
  {
    return WaysSelection.NewBuilder();
  }

  public static SystemSelection.Builder NewSystemSelectionBuilder()
  {
    return SystemSelection.NewBuilder();
  }

  public static UfCustomBetSelection.Builder NewUfCustomBetSelectionBuilder()
  {
    return UfCustomBetSelection.NewBuilder();
  }

  public static AccumulatorSelection.Builder NewAccumulatorSelectionBuilder()
  {
    return AccumulatorSelection.NewBuilder();
  }

}

public class SelectionBaseJsonConverter : JsonConverter<SelectionBase>
{

  public override SelectionBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    SelectionBase? result = type switch
    {
      "accumulator" => JsonSerializer.Deserialize<AccumulatorSelection>(root.GetRawText()),
      "external" => JsonSerializer.Deserialize<ExtSelection>(root.GetRawText()),
      "odds-boost" => JsonSerializer.Deserialize<OddsBoostSelection>(root.GetRawText()),
      "system" => JsonSerializer.Deserialize<SystemSelection>(root.GetRawText()),
      "uf" => JsonSerializer.Deserialize<UfSelection>(root.GetRawText()),
      "uf-custom-bet" => JsonSerializer.Deserialize<UfCustomBetSelection>(root.GetRawText()),
      "ways" => JsonSerializer.Deserialize<WaysSelection>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of SelectionBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null SelectionBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, SelectionBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
