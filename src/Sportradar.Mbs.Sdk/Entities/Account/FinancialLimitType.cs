using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Account;

[JsonConverter(typeof(FinancialLimitTypeJsonConverter))]
public enum FinancialLimitType
{
    DEPOSIT,
    BET,
    LOSS
}

public class FinancialLimitTypeJsonConverter : JsonConverter<FinancialLimitType>
{
    public override FinancialLimitType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonVal = reader.GetString();
        return jsonVal switch
        {
            "deposit" => FinancialLimitType.DEPOSIT,
            "bet" => FinancialLimitType.BET,
            "loss" => FinancialLimitType.LOSS,
            _ => throw new JsonException("Unknown type of FinancialLimitType: " + jsonVal)
        };
    }

    public override void Write(Utf8JsonWriter writer, FinancialLimitType value, JsonSerializerOptions options)
    {
        var jsonVal = value switch
        {
            FinancialLimitType.DEPOSIT => "deposit",
            FinancialLimitType.BET => "bet",
            FinancialLimitType.LOSS => "loss",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
        writer.WriteStringValue(jsonVal);
    }
}