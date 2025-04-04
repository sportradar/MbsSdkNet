using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Balancechangesource;

[JsonConverter(typeof(TicketBalanceChangeActionJsonConverter))]
public enum TicketBalanceChangeAction {
  PLACE,
  PAYOUT
}

public class TicketBalanceChangeActionJsonConverter : JsonConverter<TicketBalanceChangeAction> {

  public override TicketBalanceChangeAction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "place" => TicketBalanceChangeAction.PLACE,
      "payout" => TicketBalanceChangeAction.PAYOUT,
      _ => throw new JsonException("Unknown type of TicketBalanceChangeAction: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, TicketBalanceChangeAction value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      TicketBalanceChangeAction.PLACE => "place",
      TicketBalanceChangeAction.PAYOUT => "payout",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
