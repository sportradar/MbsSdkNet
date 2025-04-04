using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Accountlimit;

[JsonConverter(typeof(AccountLimitTypeJsonConverter))]
public enum AccountLimitType {
  DEPOSIT,
  SESSION,
  STAKE,
  LOSS
}

public class AccountLimitTypeJsonConverter : JsonConverter<AccountLimitType> {

  public override AccountLimitType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "deposit" => AccountLimitType.DEPOSIT,
      "session" => AccountLimitType.SESSION,
      "stake" => AccountLimitType.STAKE,
      "loss" => AccountLimitType.LOSS,
      _ => throw new JsonException("Unknown type of AccountLimitType: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, AccountLimitType value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      AccountLimitType.DEPOSIT => "deposit",
      AccountLimitType.SESSION => "session",
      AccountLimitType.STAKE => "stake",
      AccountLimitType.LOSS => "loss",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
