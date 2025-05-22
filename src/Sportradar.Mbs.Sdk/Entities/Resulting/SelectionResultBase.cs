using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Resulting;

[JsonConverter(typeof(SelectionResultBaseJsonConverter))]
public abstract class SelectionResultBase
{

  public static CancelSelectionResult.Builder NewCancelSelectionResultBuilder()
  {
    return CancelSelectionResult.NewBuilder();
  }

  public static VoidSelectionResult.Builder NewVoidSelectionResultBuilder()
  {
    return VoidSelectionResult.NewBuilder();
  }

  public static LostSelectionResult.Builder NewLostSelectionResultBuilder()
  {
    return LostSelectionResult.NewBuilder();
  }

  public static UnsettledSelectionResult.Builder NewUnsettledSelectionResultBuilder()
  {
    return UnsettledSelectionResult.NewBuilder();
  }

  public static WinSelectionResult.Builder NewWinSelectionResultBuilder()
  {
    return WinSelectionResult.NewBuilder();
  }

  public static CashoutSelectionResult.Builder NewCashoutSelectionResultBuilder()
  {
    return CashoutSelectionResult.NewBuilder();
  }
}

public class SelectionResultBaseJsonConverter : JsonConverter<SelectionResultBase>
{

  public override SelectionResultBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using var doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    SelectionResultBase? result = type switch
    {
      "cancel" => JsonSerializer.Deserialize<CancelSelectionResult>(root.GetRawText()),
      "cashout" => JsonSerializer.Deserialize<CashoutSelectionResult>(root.GetRawText()),
      "lost" => JsonSerializer.Deserialize<LostSelectionResult>(root.GetRawText()),
      "unsettled" => JsonSerializer.Deserialize<UnsettledSelectionResult>(root.GetRawText()),
      "void" => JsonSerializer.Deserialize<VoidSelectionResult>(root.GetRawText()),
      "win" => JsonSerializer.Deserialize<WinSelectionResult>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of SelectionResultBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null SelectionResultBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, SelectionResultBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }
}
