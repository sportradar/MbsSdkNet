using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

/// <summary>
/// Represents the base class for content responses.
/// </summary>
[JsonConverter(typeof(ContentResponseBaseJsonConverter))]
public abstract class ContentResponseBase
{
}

public class ContentResponseBaseJsonConverter : JsonConverter<ContentResponseBase>
{
    public override ContentResponseBase Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        var type = root.GetProperty("type").GetString();

        ContentResponseBase? result = type switch
        {
            "deposit-inform-reply" => JsonSerializer.Deserialize<DepositInformResponse>(root.GetRawText()),
            "ext-settlement-ack-reply" => JsonSerializer.Deserialize<ExtSettlementAckResponse>(root.GetRawText()),
            "cashout-reply" => JsonSerializer.Deserialize<CashoutResponse>(root.GetRawText()),
            "ticket-inform-reply" => JsonSerializer.Deserialize<TicketInformResponse>(root.GetRawText()),
            "cancel-ack-reply" => JsonSerializer.Deserialize<CancelAckResponse>(root.GetRawText()),
            "cancel-reply" => JsonSerializer.Deserialize<CancelResponse>(root.GetRawText()),
            "error-reply" => JsonSerializer.Deserialize<ErrorResponse>(root.GetRawText()),
            "casino-sessions-inform-reply" => JsonSerializer.Deserialize<CasinoSessionsResponse>(root.GetRawText()),
            "ticket-ack-reply" => JsonSerializer.Deserialize<TicketAckResponse>(root.GetRawText()),
            "balance-change-inform-reply" => JsonSerializer.Deserialize<BalanceChangeInformResponse>(root.GetRawText()),
            "ext-settlement-reply" => JsonSerializer.Deserialize<ExtSettlementResponse>(root.GetRawText()),
            "cashout-ack-reply" => JsonSerializer.Deserialize<CashoutAckResponse>(root.GetRawText()),
            "ticket-reply" => JsonSerializer.Deserialize<TicketResponse>(root.GetRawText()),
            "withdrawal-inform-reply" => JsonSerializer.Deserialize<WithdrawalInformResponse>(root.GetRawText()),
            "cashout-inform-reply" => JsonSerializer.Deserialize<CashoutInformResponse>(root.GetRawText()),
            "max-stake-reply" => JsonSerializer.Deserialize<MaxStakeResponse>(root.GetRawText()),
            "account-status-inform-reply" => JsonSerializer.Deserialize<AccountStatusInformResponse>(root.GetRawText()),
            "financial-limit-inform-reply" => JsonSerializer.Deserialize<FinancialLimitInformResponse>(root.GetRawText()),
            "session-limit-inform-reply" => JsonSerializer.Deserialize<SessionLimitInformResponse>(root.GetRawText()),
            "limit-reached-inform-reply" => JsonSerializer.Deserialize<LimitReachedInformResponse>(root.GetRawText()),
            _ => throw new JsonException("Unknown type of ContentResponseBase: " + type)
        };
        return result ?? throw new NullReferenceException("Null ContentResponseBase: " + type);
    }

    public override void Write(Utf8JsonWriter writer, ContentResponseBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}