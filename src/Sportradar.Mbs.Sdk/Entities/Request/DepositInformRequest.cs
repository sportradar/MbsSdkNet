using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class DepositInformRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "deposit-inform";

  [JsonPropertyName("walletId")]
  public String? WalletId { get; set; }

  [JsonPropertyName("depositId")]
  public String? DepositId { get; set; }

  [JsonPropertyName("amount")]
  public Amount? Amount { get; set; }

  [JsonPropertyName("endCustomer")]
  public EndCustomer? EndCustomer { get; set; }

  [JsonPropertyName("executedAtUtc")]
  public long ExecutedAtUtc { get; set; }

  [JsonPropertyName("initiatedAtUtc")]
  public long? InitiatedAtUtc { get; set; }

  [JsonPropertyName("gateway")]
  public PaymentGateway? Gateway { get; set; }

  [JsonPropertyName("status")]
  public BalanceMoveStatus? Status { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly DepositInformRequest instance = new DepositInformRequest();

    internal Builder()
    {
    }

    public DepositInformRequest Build()
    {
      return this.instance;
    }

    public Builder SetWalletId(String value)
    {
      this.instance.WalletId = value;
      return this;
    }

    public Builder SetDepositId(String value)
    {
      this.instance.DepositId = value;
      return this;
    }

    public Builder SetAmount(Amount value)
    {
      this.instance.Amount = value;
      return this;
    }

    public Builder SetEndCustomer(EndCustomer value)
    {
      this.instance.EndCustomer = value;
      return this;
    }

    public Builder SetExecutedAtUtc(long value)
    {
      this.instance.ExecutedAtUtc = value;
      return this;
    }

    public Builder SetInitiatedAtUtc(long value)
    {
      this.instance.InitiatedAtUtc = value;
      return this;
    }

    public Builder SetGateway(PaymentGateway value)
    {
      this.instance.Gateway = value;
      return this;
    }

    public Builder SetStatus(BalanceMoveStatus value)
    {
      this.instance.Status = value;
      return this;
    }
  }
}
