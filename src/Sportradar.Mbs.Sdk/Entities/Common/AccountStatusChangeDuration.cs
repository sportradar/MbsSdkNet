using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(AccountStatusChangeDurationJsonConverter))]
public enum AccountStatusChangeDuration {
  PERMANENT,
  TEMPORARY
}

public class AccountStatusChangeDurationJsonConverter : JsonConverter<AccountStatusChangeDuration> {

  public override AccountStatusChangeDuration Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "permanent" => AccountStatusChangeDuration.PERMANENT,
      "temporary" => AccountStatusChangeDuration.TEMPORARY,
      _ => throw new JsonException("Unknown type of AccountStatusChangeDuration: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, AccountStatusChangeDuration value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      AccountStatusChangeDuration.PERMANENT => "permanent",
      AccountStatusChangeDuration.TEMPORARY => "temporary",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
