using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Accountlimit;

[JsonConverter(typeof(AccountLimitBaseJsonConverter))]
public abstract class AccountLimitBase
{

  public static StakeAccountLimit.Builder NewStakeAccountLimitBuilder()
  {
    return StakeAccountLimit.NewBuilder();
  }

  public static LossAccountLimit.Builder NewLossAccountLimitBuilder()
  {
    return LossAccountLimit.NewBuilder();
  }

  public static SessionAccountLimit.Builder NewSessionAccountLimitBuilder()
  {
    return SessionAccountLimit.NewBuilder();
  }

  public static DepositAccountLimit.Builder NewDepositAccountLimitBuilder()
  {
    return DepositAccountLimit.NewBuilder();
  }

}

public class AccountLimitBaseJsonConverter : JsonConverter<AccountLimitBase>
{

  public override AccountLimitBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    AccountLimitBase? result = type switch
    {
      "deposit" => JsonSerializer.Deserialize<DepositAccountLimit>(root.GetRawText()),
      "loss" => JsonSerializer.Deserialize<LossAccountLimit>(root.GetRawText()),
      "session" => JsonSerializer.Deserialize<SessionAccountLimit>(root.GetRawText()),
      "stake" => JsonSerializer.Deserialize<StakeAccountLimit>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of AccountLimitBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null AccountLimitBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, AccountLimitBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
