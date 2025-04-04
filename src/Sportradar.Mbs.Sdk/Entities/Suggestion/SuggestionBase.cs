using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Suggestion;

[JsonConverter(typeof(SuggestionBaseJsonConverter))]
public abstract class SuggestionBase
{

  public static AltStakeSuggestion.Builder NewAltStakeSuggestionBuilder()
  {
    return AltStakeSuggestion.NewBuilder();
  }

  public static ReofferSuggestion.Builder NewReofferSuggestionBuilder()
  {
    return ReofferSuggestion.NewBuilder();
  }

}

public class SuggestionBaseJsonConverter : JsonConverter<SuggestionBase>
{

  public override SuggestionBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    SuggestionBase? result = type switch
    {
      "alt-stake" => JsonSerializer.Deserialize<AltStakeSuggestion>(root.GetRawText()),
      "reoffer" => JsonSerializer.Deserialize<ReofferSuggestion>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of SuggestionBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null SuggestionBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, SuggestionBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
