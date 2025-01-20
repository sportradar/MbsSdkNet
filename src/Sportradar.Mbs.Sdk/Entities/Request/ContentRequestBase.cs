using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a base class for content requests.
/// </summary>
[JsonConverter(typeof(ContentRequestBaseJsonConverter))]
public abstract class ContentRequestBase
{
}

public class ContentRequestBaseJsonConverter : JsonConverter<ContentRequestBase>
{
    public override ContentRequestBase Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        var type = root.GetProperty("type").GetString();

        ContentRequestBase? result = type switch
        {
            "cancel" => JsonSerializer.Deserialize<CancelRequest>(root.GetRawText()),
            "ticket-inform" => JsonSerializer.Deserialize<TicketInformRequest>(root.GetRawText()),
            "ticket" => JsonSerializer.Deserialize<TicketRequest>(root.GetRawText()),
            "cashout-ack" => JsonSerializer.Deserialize<CashoutAckRequest>(root.GetRawText()),
            "deposit-inform" => JsonSerializer.Deserialize<DepositInformRequest>(root.GetRawText()),
            "cashout" => JsonSerializer.Deserialize<CashoutRequest>(root.GetRawText()),
            "casino-sessions-inform" => JsonSerializer.Deserialize<CasinoSessionsRequest>(root.GetRawText()),
            "ticket-ack" => JsonSerializer.Deserialize<TicketAckRequest>(root.GetRawText()),
            "ext-settlement" => JsonSerializer.Deserialize<ExtSettlementRequest>(root.GetRawText()),
            "cancel-ack" => JsonSerializer.Deserialize<CancelAckRequest>(root.GetRawText()),
            "withdrawal-inform" => JsonSerializer.Deserialize<WithdrawalInformRequest>(root.GetRawText()),
            "ext-settlement-ack" => JsonSerializer.Deserialize<ExtSettlementAckRequest>(root.GetRawText()),
            "balance-change-inform" => JsonSerializer.Deserialize<BalanceChangeInformRequest>(root.GetRawText()),
            "cashout-inform" => JsonSerializer.Deserialize<CashoutInformRequest>(root.GetRawText()),
            "max-stake" => JsonSerializer.Deserialize<MaxStakeRequest>(root.GetRawText()),
            "financial-limit-inform-reply" => JsonSerializer.Deserialize<FinancialLimitInformRequest>(root.GetRawText()),
            "session-limit-inform-reply" => JsonSerializer.Deserialize<SessionLimitInformRequest>(root.GetRawText()),
            "limit-reached-inform-reply" => JsonSerializer.Deserialize<LimitReachedInformRequest>(root.GetRawText()),
            _ => throw new JsonException("Unknown type of ContentRequestBase: " + type)
        };
        return result ?? throw new NullReferenceException("Null ContentRequestBase: " + type);
    }

    public override void Write(Utf8JsonWriter writer, ContentRequestBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}