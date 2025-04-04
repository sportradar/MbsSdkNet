using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(AccountStatusChangeInitiatorJsonConverter))]
public enum AccountStatusChangeInitiator {
  OPERATOR,
  OTHER,
  REGULATOR,
  PLAYER
}

public class AccountStatusChangeInitiatorJsonConverter : JsonConverter<AccountStatusChangeInitiator> {

  public override AccountStatusChangeInitiator Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "operator" => AccountStatusChangeInitiator.OPERATOR,
      "other" => AccountStatusChangeInitiator.OTHER,
      "regulator" => AccountStatusChangeInitiator.REGULATOR,
      "player" => AccountStatusChangeInitiator.PLAYER,
      _ => throw new JsonException("Unknown type of AccountStatusChangeInitiator: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, AccountStatusChangeInitiator value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      AccountStatusChangeInitiator.OPERATOR => "operator",
      AccountStatusChangeInitiator.OTHER => "other",
      AccountStatusChangeInitiator.REGULATOR => "regulator",
      AccountStatusChangeInitiator.PLAYER => "player",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
