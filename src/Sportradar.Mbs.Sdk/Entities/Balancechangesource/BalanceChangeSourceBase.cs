using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Balancechangesource;

[JsonConverter(typeof(BalanceChangeSourceBaseJsonConverter))]
public abstract class BalanceChangeSourceBase
{

  public static TicketBalanceChangeSource.Builder NewTicketBalanceChangeSourceBuilder()
  {
    return TicketBalanceChangeSource.NewBuilder();
  }

  public static DepositBalanceChangeSource.Builder NewDepositBalanceChangeSourceBuilder()
  {
    return DepositBalanceChangeSource.NewBuilder();
  }

  public static WithdrawalBalanceChangeSource.Builder NewWithdrawalBalanceChangeSourceBuilder()
  {
    return WithdrawalBalanceChangeSource.NewBuilder();
  }

}

public class BalanceChangeSourceBaseJsonConverter : JsonConverter<BalanceChangeSourceBase>
{

  public override BalanceChangeSourceBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    BalanceChangeSourceBase? result = type switch
    {
      "deposit" => JsonSerializer.Deserialize<DepositBalanceChangeSource>(root.GetRawText()),
      "ticket" => JsonSerializer.Deserialize<TicketBalanceChangeSource>(root.GetRawText()),
      "withdrawal" => JsonSerializer.Deserialize<WithdrawalBalanceChangeSource>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of BalanceChangeSourceBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null BalanceChangeSourceBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, BalanceChangeSourceBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
