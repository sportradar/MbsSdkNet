using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Cancellation;

[JsonConverter(typeof(CancelDetailsBaseJsonConverter))]
public abstract class CancelDetailsBase
{

  public static BetCancelDetails.Builder NewBetCancelDetailsBuilder()
  {
    return BetCancelDetails.NewBuilder();
  }

  public static ReofferCancelDetails.Builder NewReofferCancelDetailsBuilder()
  {
    return ReofferCancelDetails.NewBuilder();
  }

  public static TicketCancelDetails.Builder NewTicketCancelDetailsBuilder()
  {
    return TicketCancelDetails.NewBuilder();
  }

  public static TicketPartialCancelDetails.Builder NewTicketPartialCancelDetailsBuilder()
  {
    return TicketPartialCancelDetails.NewBuilder();
  }

  public static BetPartialCancelDetails.Builder NewBetPartialCancelDetailsBuilder()
  {
    return BetPartialCancelDetails.NewBuilder();
  }

}

public class CancelDetailsBaseJsonConverter : JsonConverter<CancelDetailsBase>
{

  public override CancelDetailsBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    CancelDetailsBase? result = type switch
    {
      "bet" => JsonSerializer.Deserialize<BetCancelDetails>(root.GetRawText()),
      "bet-partial" => JsonSerializer.Deserialize<BetPartialCancelDetails>(root.GetRawText()),
      "reoffer" => JsonSerializer.Deserialize<ReofferCancelDetails>(root.GetRawText()),
      "ticket" => JsonSerializer.Deserialize<TicketCancelDetails>(root.GetRawText()),
      "ticket-partial" => JsonSerializer.Deserialize<TicketPartialCancelDetails>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of CancelDetailsBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null CancelDetailsBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, CancelDetailsBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
