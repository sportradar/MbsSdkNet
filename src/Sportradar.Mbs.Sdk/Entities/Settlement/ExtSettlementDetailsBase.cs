using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Settlement;

[JsonConverter(typeof(ExtSettlementDetailsBaseJsonConverter))]
public abstract class ExtSettlementDetailsBase
{

  public static BetExtSettlementDetails.Builder NewBetExtSettlementDetailsBuilder()
  {
    return BetExtSettlementDetails.NewBuilder();
  }

  public static TicketExtSettlementDetails.Builder NewTicketExtSettlementDetailsBuilder()
  {
    return TicketExtSettlementDetails.NewBuilder();
  }

}

public class ExtSettlementDetailsBaseJsonConverter : JsonConverter<ExtSettlementDetailsBase>
{

  public override ExtSettlementDetailsBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    ExtSettlementDetailsBase? result = type switch
    {
      "bet" => JsonSerializer.Deserialize<BetExtSettlementDetails>(root.GetRawText()),
      "ticket" => JsonSerializer.Deserialize<TicketExtSettlementDetails>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of ExtSettlementDetailsBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null ExtSettlementDetailsBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, ExtSettlementDetailsBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
