using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Autocashoutcancellation;

[JsonConverter(typeof(AutoCashoutCancelDetailsBaseJsonConverter))]
public abstract class AutoCashoutCancelDetailsBase
{

  public static BetAutoCashoutCancelDetails.Builder NewBetAutoCashoutCancelDetailsBuilder()
  {
    return BetAutoCashoutCancelDetails.NewBuilder();
  }

  public static TicketAutoCashoutCancelDetails.Builder NewTicketAutoCashoutCancelDetailsBuilder()
  {
    return TicketAutoCashoutCancelDetails.NewBuilder();
  }

}

public class AutoCashoutCancelDetailsBaseJsonConverter : JsonConverter<AutoCashoutCancelDetailsBase>
{
  public override AutoCashoutCancelDetailsBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    AutoCashoutCancelDetailsBase? result = type switch
    {
      "bet" => JsonSerializer.Deserialize<BetAutoCashoutCancelDetails>(root.GetRawText()),
      "ticket" => JsonSerializer.Deserialize<TicketAutoCashoutCancelDetails>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of AutoCashoutCancelDetailsBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null AutoCashoutCancelDetailsBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, AutoCashoutCancelDetailsBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
