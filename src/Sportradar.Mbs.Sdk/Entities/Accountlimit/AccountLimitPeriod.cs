using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Accountlimit;

[JsonConverter(typeof(AccountLimitPeriodJsonConverter))]
public enum AccountLimitPeriod {
  MONTHLY,
  WEEKLY,
  DAILY
}

public class AccountLimitPeriodJsonConverter : JsonConverter<AccountLimitPeriod> {

  public override AccountLimitPeriod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "monthly" => AccountLimitPeriod.MONTHLY,
      "weekly" => AccountLimitPeriod.WEEKLY,
      "daily" => AccountLimitPeriod.DAILY,
      _ => throw new JsonException("Unknown type of AccountLimitPeriod: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, AccountLimitPeriod value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      AccountLimitPeriod.MONTHLY => "monthly",
      AccountLimitPeriod.WEEKLY => "weekly",
      AccountLimitPeriod.DAILY => "daily",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
