using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(PaymentMethodJsonConverter))]
public enum PaymentMethod {
  CREDIT_CARD,
  DEBIT_CART,
  PREPAID_CARD,
  BANK_TRANSFER,
  E_WALLET
}

public class PaymentMethodJsonConverter : JsonConverter<PaymentMethod> {

  public override PaymentMethod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "credit-card" => PaymentMethod.CREDIT_CARD,
      "debit-card" => PaymentMethod.DEBIT_CART,
      "prepaid-card" => PaymentMethod.PREPAID_CARD,
      "bank-transfer" => PaymentMethod.BANK_TRANSFER,
      "e-wallet" => PaymentMethod.E_WALLET,
      _ => throw new JsonException("Unknown type of PaymentMethod: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, PaymentMethod value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      PaymentMethod.CREDIT_CARD => "credit-card",
      PaymentMethod.DEBIT_CART => "debit-card",
      PaymentMethod.PREPAID_CARD => "prepaid-card",
      PaymentMethod.BANK_TRANSFER => "bank-transfer",
      PaymentMethod.E_WALLET => "e-wallet",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
