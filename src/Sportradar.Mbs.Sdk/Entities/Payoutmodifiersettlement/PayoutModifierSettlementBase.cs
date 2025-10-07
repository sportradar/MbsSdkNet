using Sportradar.Mbs.Sdk.Entities.Payoutmodifiersettlement;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Payoutmodifiersettlement;

[JsonConverter(typeof(PayoutModifierSettlementBaseJsonConverter))]
public abstract class PayoutModifierSettlementBase
{
  public static ResultPayoutModifierSettlement.Builder NewResultPayoutModifierSettlementBuilder()
  {
    return ResultPayoutModifierSettlement.NewBuilder();
  }

  public static OddsPayoutModifierSettlement.Builder NewOddsPayoutModifierSettlementBuilder()
  {
    return OddsPayoutModifierSettlement.NewBuilder();
  }
}

public class PayoutModifierSettlementBaseJsonConverter : JsonConverter<PayoutModifierSettlementBase>
{
  public override PayoutModifierSettlementBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    PayoutModifierSettlementBase? result = type switch
    {
      "odds" => JsonSerializer.Deserialize<OddsPayoutModifierSettlement>(root.GetRawText()),
      "result" => JsonSerializer.Deserialize<ResultPayoutModifierSettlement>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of PayoutModifierSettlementBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null PayoutModifierSettlementBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, PayoutModifierSettlementBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }
}