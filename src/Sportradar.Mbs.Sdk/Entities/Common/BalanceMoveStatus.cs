using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(BalanceMoveStatusJsonConverter))]
public enum BalanceMoveStatus
{
    PENDING,
    APPROVED,
    REJECTED,
    CANCELLED
}

public class BalanceMoveStatusJsonConverter : JsonConverter<BalanceMoveStatus>
{
    public override BalanceMoveStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonVal = reader.GetString();
        return jsonVal switch
        {
            "pending" => BalanceMoveStatus.PENDING,
            "approved" => BalanceMoveStatus.APPROVED,
            "rejected" => BalanceMoveStatus.REJECTED,
            "cancelled" => BalanceMoveStatus.CANCELLED,
            _ => throw new JsonException("Unknown type of BalanceMoveStatus: " + jsonVal)
        };
    }

    public override void Write(Utf8JsonWriter writer, BalanceMoveStatus value, JsonSerializerOptions options)
    {
        var jsonVal = value switch
        {
            BalanceMoveStatus.PENDING => "pending",
            BalanceMoveStatus.APPROVED => "approved",
            BalanceMoveStatus.REJECTED => "rejected",
            BalanceMoveStatus.CANCELLED => "cancelled",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
        };
        writer.WriteStringValue(jsonVal);
    }
}