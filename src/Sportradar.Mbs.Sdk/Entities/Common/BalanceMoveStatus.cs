using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(BalanceMoveStatusJsonConverter))]
public enum BalanceMoveStatus {
  APPROVED,
  CANCELLED,
  PENDING,
  REJECTED
}

public class BalanceMoveStatusJsonConverter : JsonConverter<BalanceMoveStatus> {

  public override BalanceMoveStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "approved" => BalanceMoveStatus.APPROVED,
      "cancelled" => BalanceMoveStatus.CANCELLED,
      "pending" => BalanceMoveStatus.PENDING,
      "rejected" => BalanceMoveStatus.REJECTED,
      _ => throw new JsonException("Unknown type of BalanceMoveStatus: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, BalanceMoveStatus value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      BalanceMoveStatus.APPROVED => "approved",
      BalanceMoveStatus.CANCELLED => "cancelled",
      BalanceMoveStatus.PENDING => "pending",
      BalanceMoveStatus.REJECTED => "rejected",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
