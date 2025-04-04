using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Payout;

[JsonConverter(typeof(PayoutBaseJsonConverter))]
public abstract class PayoutBase
{

  public static FreePayout.Builder NewFreePayoutBuilder()
  {
    return FreePayout.NewBuilder();
  }

  public static WithheldPayout.Builder NewWithheldPayoutBuilder()
  {
    return WithheldPayout.NewBuilder();
  }

  public static CashPayout.Builder NewCashPayoutBuilder()
  {
    return CashPayout.NewBuilder();
  }

}

public class PayoutBaseJsonConverter : JsonConverter<PayoutBase>
{

  public override PayoutBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    PayoutBase? result = type switch
    {
      "cash" => JsonSerializer.Deserialize<CashPayout>(root.GetRawText()),
      "free" => JsonSerializer.Deserialize<FreePayout>(root.GetRawText()),
      "withheld" => JsonSerializer.Deserialize<WithheldPayout>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of PayoutBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null PayoutBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, PayoutBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
