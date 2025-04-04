using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Stake;

[JsonConverter(typeof(StakeBaseJsonConverter))]
public abstract class StakeBase
{

  public static FreeRolloverStake.Builder NewFreeRolloverStakeBuilder()
  {
    return FreeRolloverStake.NewBuilder();
  }

  public static FreeCashStake.Builder NewFreeCashStakeBuilder()
  {
    return FreeCashStake.NewBuilder();
  }

  public static BonusStake.Builder NewBonusStakeBuilder()
  {
    return BonusStake.NewBuilder();
  }

  public static FreeStake.Builder NewFreeStakeBuilder()
  {
    return FreeStake.NewBuilder();
  }

  public static CashStake.Builder NewCashStakeBuilder()
  {
    return CashStake.NewBuilder();
  }

}

public class StakeBaseJsonConverter : JsonConverter<StakeBase>
{

  public override StakeBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    StakeBase? result = type switch
    {
      "bonus" => JsonSerializer.Deserialize<BonusStake>(root.GetRawText()),
      "cash" => JsonSerializer.Deserialize<CashStake>(root.GetRawText()),
      "free" => JsonSerializer.Deserialize<FreeStake>(root.GetRawText()),
      "free-cash" => JsonSerializer.Deserialize<FreeCashStake>(root.GetRawText()),
      "free-rollover" => JsonSerializer.Deserialize<FreeRolloverStake>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of StakeBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null StakeBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, StakeBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
