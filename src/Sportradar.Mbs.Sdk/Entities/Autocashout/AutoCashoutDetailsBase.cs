using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Autocashout;

[JsonConverter(typeof(AutoCashoutDetailsBaseJsonConverter))]
public abstract class AutoCashoutDetailsBase
{

  public static BetAutoCashoutDetails.Builder NewBetAutoCashoutDetailsBuilder()
  {
    return BetAutoCashoutDetails.NewBuilder();
  }

  public static TicketAutoCashoutDetails.Builder NewTicketAutoCashoutDetailsBuilder()
  {
    return TicketAutoCashoutDetails.NewBuilder();
  }

}

public class AutoCashoutDetailsBaseJsonConverter : JsonConverter<AutoCashoutDetailsBase>
{
  public override AutoCashoutDetailsBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    AutoCashoutDetailsBase? result = type switch
    {
      "bet" => JsonSerializer.Deserialize<BetAutoCashoutDetails>(root.GetRawText()),
      "ticket" => JsonSerializer.Deserialize<TicketAutoCashoutDetails>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of AutoCashoutDetailsBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null AutoCashoutDetailsBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, AutoCashoutDetailsBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
