using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(AccountStatusJsonConverter))]
public enum AccountStatus {
  EXCLUDED,
  ACTIVE,
  DISABLED
}

public class AccountStatusJsonConverter : JsonConverter<AccountStatus> {

  public override AccountStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "excluded" => AccountStatus.EXCLUDED,
      "active" => AccountStatus.ACTIVE,
      "disabled" => AccountStatus.DISABLED,
      _ => throw new JsonException("Unknown type of AccountStatus: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, AccountStatus value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      AccountStatus.EXCLUDED => "excluded",
      AccountStatus.ACTIVE => "active",
      AccountStatus.DISABLED => "disabled",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
