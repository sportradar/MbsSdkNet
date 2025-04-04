using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(PaymentMethodJsonConverter))]
public enum PaymentMethod {
  CREDIT_CARD
}

public class PaymentMethodJsonConverter : JsonConverter<PaymentMethod> {

  public override PaymentMethod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "credit-card" => PaymentMethod.CREDIT_CARD,
      _ => throw new JsonException("Unknown type of PaymentMethod: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, PaymentMethod value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      PaymentMethod.CREDIT_CARD => "credit-card",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
