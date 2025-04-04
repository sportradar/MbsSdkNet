using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(BalanceChangeStatusJsonConverter))]
public enum BalanceChangeStatus {
  INVALID,
  VALID
}

public class BalanceChangeStatusJsonConverter : JsonConverter<BalanceChangeStatus> {

  public override BalanceChangeStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "invalid" => BalanceChangeStatus.INVALID,
      "valid" => BalanceChangeStatus.VALID,
      _ => throw new JsonException("Unknown type of BalanceChangeStatus: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, BalanceChangeStatus value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      BalanceChangeStatus.INVALID => "invalid",
      BalanceChangeStatus.VALID => "valid",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
