using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Autocashoutthreshold;

[JsonConverter(typeof(AutoCashoutThresholdBaseJsonConverter))]
public abstract class AutoCashoutThresholdBase
{

  public static TakeWinAutoCashoutThreshold.Builder NewTakeWinAutoCashoutThresholdBuilder()
  {
    return TakeWinAutoCashoutThreshold.NewBuilder();
  }

  public static StopLossAutoCashoutThreshold.Builder NewStopLossAutoCashoutThresholdBuilder()
  {
    return StopLossAutoCashoutThreshold.NewBuilder();
  }

}

public class AutoCashoutThresholdBaseJsonConverter : JsonConverter<AutoCashoutThresholdBase>
{
  public override AutoCashoutThresholdBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    AutoCashoutThresholdBase? result = type switch
    {
      "stop-loss" => JsonSerializer.Deserialize<StopLossAutoCashoutThreshold>(root.GetRawText()),
      "take-win" => JsonSerializer.Deserialize<TakeWinAutoCashoutThreshold>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of AutoCashoutThresholdBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null AutoCashoutThresholdBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, AutoCashoutThresholdBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
