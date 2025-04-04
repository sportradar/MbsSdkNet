using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

[JsonConverter(typeof(ContentRequestBaseJsonConverter))]
public abstract class ContentRequestBase
{

  public static TicketInformRequest.Builder NewTicketInformRequestBuilder()
  {
    return TicketInformRequest.NewBuilder();
  }

  public static CancelRequest.Builder NewCancelRequestBuilder()
  {
    return CancelRequest.NewBuilder();
  }

  public static AccountInterventionInformRequest.Builder NewAccountInterventionInformRequestBuilder()
  {
    return AccountInterventionInformRequest.NewBuilder();
  }

  public static MaxStakeRequest.Builder NewMaxStakeRequestBuilder()
  {
    return MaxStakeRequest.NewBuilder();
  }

  public static TicketRequest.Builder NewTicketRequestBuilder()
  {
    return TicketRequest.NewBuilder();
  }

  public static CashoutBuildRequest.Builder NewCashoutBuildRequestBuilder()
  {
    return CashoutBuildRequest.NewBuilder();
  }

  public static CashoutAckRequest.Builder NewCashoutAckRequestBuilder()
  {
    return CashoutAckRequest.NewBuilder();
  }

  public static AccountStatusInformRequest.Builder NewAccountStatusInformRequestBuilder()
  {
    return AccountStatusInformRequest.NewBuilder();
  }

  public static DepositInformRequest.Builder NewDepositInformRequestBuilder()
  {
    return DepositInformRequest.NewBuilder();
  }

  public static CasinoSessionsRequest.Builder NewCasinoSessionsRequestBuilder()
  {
    return CasinoSessionsRequest.NewBuilder();
  }

  public static CashoutRequest.Builder NewCashoutRequestBuilder()
  {
    return CashoutRequest.NewBuilder();
  }

  public static TicketAckRequest.Builder NewTicketAckRequestBuilder()
  {
    return TicketAckRequest.NewBuilder();
  }

  public static TicketBuildRequest.Builder NewTicketBuildRequestBuilder()
  {
    return TicketBuildRequest.NewBuilder();
  }

  public static ExtSettlementRequest.Builder NewExtSettlementRequestBuilder()
  {
    return ExtSettlementRequest.NewBuilder();
  }

  public static CashoutInformRequest.Builder NewCashoutInformRequestBuilder()
  {
    return CashoutInformRequest.NewBuilder();
  }

  public static CancelAckRequest.Builder NewCancelAckRequestBuilder()
  {
    return CancelAckRequest.NewBuilder();
  }

  public static WithdrawalInformRequest.Builder NewWithdrawalInformRequestBuilder()
  {
    return WithdrawalInformRequest.NewBuilder();
  }

  public static AccountLimitInformRequest.Builder NewAccountLimitInformRequestBuilder()
  {
    return AccountLimitInformRequest.NewBuilder();
  }

  public static AccountLimitReachedInformRequest.Builder NewAccountLimitReachedInformRequestBuilder()
  {
    return AccountLimitReachedInformRequest.NewBuilder();
  }

  public static ExtSettlementAckRequest.Builder NewExtSettlementAckRequestBuilder()
  {
    return ExtSettlementAckRequest.NewBuilder();
  }

  public static BalanceChangeInformRequest.Builder NewBalanceChangeInformRequestBuilder()
  {
    return BalanceChangeInformRequest.NewBuilder();
  }

}

public class ContentRequestBaseJsonConverter : JsonConverter<ContentRequestBase>
{

  public override ContentRequestBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    ContentRequestBase? result = type switch
    {
      "account-intervention-inform" => JsonSerializer.Deserialize<AccountInterventionInformRequest>(root.GetRawText()),
      "account-limit-inform" => JsonSerializer.Deserialize<AccountLimitInformRequest>(root.GetRawText()),
      "account-limit-reached-inform" => JsonSerializer.Deserialize<AccountLimitReachedInformRequest>(root.GetRawText()),
      "account-status-inform" => JsonSerializer.Deserialize<AccountStatusInformRequest>(root.GetRawText()),
      "balance-change-inform" => JsonSerializer.Deserialize<BalanceChangeInformRequest>(root.GetRawText()),
      "cancel" => JsonSerializer.Deserialize<CancelRequest>(root.GetRawText()),
      "cancel-ack" => JsonSerializer.Deserialize<CancelAckRequest>(root.GetRawText()),
      "cashout" => JsonSerializer.Deserialize<CashoutRequest>(root.GetRawText()),
      "cashout-ack" => JsonSerializer.Deserialize<CashoutAckRequest>(root.GetRawText()),
      "cashout-build" => JsonSerializer.Deserialize<CashoutBuildRequest>(root.GetRawText()),
      "cashout-inform" => JsonSerializer.Deserialize<CashoutInformRequest>(root.GetRawText()),
      "casino-sessions-inform" => JsonSerializer.Deserialize<CasinoSessionsRequest>(root.GetRawText()),
      "deposit-inform" => JsonSerializer.Deserialize<DepositInformRequest>(root.GetRawText()),
      "ext-settlement" => JsonSerializer.Deserialize<ExtSettlementRequest>(root.GetRawText()),
      "ext-settlement-ack" => JsonSerializer.Deserialize<ExtSettlementAckRequest>(root.GetRawText()),
      "max-stake" => JsonSerializer.Deserialize<MaxStakeRequest>(root.GetRawText()),
      "ticket" => JsonSerializer.Deserialize<TicketRequest>(root.GetRawText()),
      "ticket-ack" => JsonSerializer.Deserialize<TicketAckRequest>(root.GetRawText()),
      "ticket-build" => JsonSerializer.Deserialize<TicketBuildRequest>(root.GetRawText()),
      "ticket-inform" => JsonSerializer.Deserialize<TicketInformRequest>(root.GetRawText()),
      "withdrawal-inform" => JsonSerializer.Deserialize<WithdrawalInformRequest>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of ContentRequestBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null ContentRequestBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, ContentRequestBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
