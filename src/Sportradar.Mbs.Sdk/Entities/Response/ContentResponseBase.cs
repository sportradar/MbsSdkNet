using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

[JsonConverter(typeof(ContentResponseBaseJsonConverter))]
public abstract class ContentResponseBase
{

  public static DepositInformResponse.Builder NewDepositInformResponseBuilder()
  {
    return DepositInformResponse.NewBuilder();
  }

  public static AccountLimitInformResponse.Builder NewAccountLimitInformResponseBuilder()
  {
    return AccountLimitInformResponse.NewBuilder();
  }

  public static ExtSettlementAckResponse.Builder NewExtSettlementAckResponseBuilder()
  {
    return ExtSettlementAckResponse.NewBuilder();
  }

  public static CashoutInformResponse.Builder NewCashoutInformResponseBuilder()
  {
    return CashoutInformResponse.NewBuilder();
  }

  public static CashoutPlacementResponse.Builder NewCashoutPlacementResponseBuilder()
  {
    return CashoutPlacementResponse.NewBuilder();
  }

  public static AccountStatusInformResponse.Builder NewAccountStatusInformResponseBuilder()
  {
    return AccountStatusInformResponse.NewBuilder();
  }

  public static CashoutBuildResponse.Builder NewCashoutBuildResponseBuilder()
  {
    return CashoutBuildResponse.NewBuilder();
  }

  public static AccountLimitReachedInformResponse.Builder NewAccountLimitReachedInformResponseBuilder()
  {
    return AccountLimitReachedInformResponse.NewBuilder();
  }

  public static TicketInformResponse.Builder NewTicketInformResponseBuilder()
  {
    return TicketInformResponse.NewBuilder();
  }

  public static CashoutResponse.Builder NewCashoutResponseBuilder()
  {
    return CashoutResponse.NewBuilder();
  }

  public static CancelResponse.Builder NewCancelResponseBuilder()
  {
    return CancelResponse.NewBuilder();
  }

  public static CancelAckResponse.Builder NewCancelAckResponseBuilder()
  {
    return CancelAckResponse.NewBuilder();
  }

  public static TicketBuildResponse.Builder NewTicketBuildResponseBuilder()
  {
    return TicketBuildResponse.NewBuilder();
  }

  public static MaxStakeResponse.Builder NewMaxStakeResponseBuilder()
  {
    return MaxStakeResponse.NewBuilder();
  }

  public static ErrorResponse.Builder NewErrorResponseBuilder()
  {
    return ErrorResponse.NewBuilder();
  }

  public static CasinoSessionsResponse.Builder NewCasinoSessionsResponseBuilder()
  {
    return CasinoSessionsResponse.NewBuilder();
  }

  public static TicketAckResponse.Builder NewTicketAckResponseBuilder()
  {
    return TicketAckResponse.NewBuilder();
  }

  public static BalanceChangeInformResponse.Builder NewBalanceChangeInformResponseBuilder()
  {
    return BalanceChangeInformResponse.NewBuilder();
  }

  public static AccountInterventionInformResponse.Builder NewAccountInterventionInformResponseBuilder()
  {
    return AccountInterventionInformResponse.NewBuilder();
  }

  public static ExtSettlementResponse.Builder NewExtSettlementResponseBuilder()
  {
    return ExtSettlementResponse.NewBuilder();
  }

  public static CashoutAckResponse.Builder NewCashoutAckResponseBuilder()
  {
    return CashoutAckResponse.NewBuilder();
  }

  public static TicketResponse.Builder NewTicketResponseBuilder()
  {
    return TicketResponse.NewBuilder();
  }

  public static WithdrawalInformResponse.Builder NewWithdrawalInformResponseBuilder()
  {
    return WithdrawalInformResponse.NewBuilder();
  }

}

public class ContentResponseBaseJsonConverter : JsonConverter<ContentResponseBase>
{

  public override ContentResponseBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    ContentResponseBase? result = type switch
    {
      "account-intervention-inform-reply" => JsonSerializer.Deserialize<AccountInterventionInformResponse>(root.GetRawText()),
      "account-limit-inform-reply" => JsonSerializer.Deserialize<AccountLimitInformResponse>(root.GetRawText()),
      "account-limit-reached-inform-reply" => JsonSerializer.Deserialize<AccountLimitReachedInformResponse>(root.GetRawText()),
      "account-status-inform-reply" => JsonSerializer.Deserialize<AccountStatusInformResponse>(root.GetRawText()),
      "balance-change-inform-reply" => JsonSerializer.Deserialize<BalanceChangeInformResponse>(root.GetRawText()),
      "cancel-ack-reply" => JsonSerializer.Deserialize<CancelAckResponse>(root.GetRawText()),
      "cancel-reply" => JsonSerializer.Deserialize<CancelResponse>(root.GetRawText()),
      "cashout-ack-reply" => JsonSerializer.Deserialize<CashoutAckResponse>(root.GetRawText()),
      "cashout-build-reply" => JsonSerializer.Deserialize<CashoutBuildResponse>(root.GetRawText()),
      "cashout-inform-reply" => JsonSerializer.Deserialize<CashoutInformResponse>(root.GetRawText()),
      "cashout-placement-reply" => JsonSerializer.Deserialize<CashoutPlacementResponse>(root.GetRawText()),
      "cashout-reply" => JsonSerializer.Deserialize<CashoutResponse>(root.GetRawText()),
      "casino-sessions-inform-reply" => JsonSerializer.Deserialize<CasinoSessionsResponse>(root.GetRawText()),
      "deposit-inform-reply" => JsonSerializer.Deserialize<DepositInformResponse>(root.GetRawText()),
      "error-reply" => JsonSerializer.Deserialize<ErrorResponse>(root.GetRawText()),
      "ext-settlement-ack-reply" => JsonSerializer.Deserialize<ExtSettlementAckResponse>(root.GetRawText()),
      "ext-settlement-reply" => JsonSerializer.Deserialize<ExtSettlementResponse>(root.GetRawText()),
      "max-stake-reply" => JsonSerializer.Deserialize<MaxStakeResponse>(root.GetRawText()),
      "ticket-ack-reply" => JsonSerializer.Deserialize<TicketAckResponse>(root.GetRawText()),
      "ticket-build-reply" => JsonSerializer.Deserialize<TicketBuildResponse>(root.GetRawText()),
      "ticket-inform-reply" => JsonSerializer.Deserialize<TicketInformResponse>(root.GetRawText()),
      "ticket-reply" => JsonSerializer.Deserialize<TicketResponse>(root.GetRawText()),
      "withdrawal-inform-reply" => JsonSerializer.Deserialize<WithdrawalInformResponse>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of ContentResponseBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null ContentResponseBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, ContentResponseBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
