using Sportradar.Mbs.Sdk.Entities.Balancechangesource;
using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class BalanceChangeInformRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "balance-change-inform";

  [JsonPropertyName("walletId")]
  public String? WalletId { get; set; }

  [JsonPropertyName("balanceChangeId")]
  public String? BalanceChangeId { get; set; }

  [JsonPropertyName("amount")]
  public Amount? Amount { get; set; }

  [JsonPropertyName("endCustomer")]
  public EndCustomer? EndCustomer { get; set; }

  [JsonPropertyName("executedAtUtc")]
  public long ExecutedAtUtc { get; set; }

  [JsonPropertyName("source")]
  public BalanceChangeSourceBase? Source { get; set; }

  [JsonPropertyName("status")]
  public BalanceChangeStatus? Status { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly BalanceChangeInformRequest instance = new BalanceChangeInformRequest();

    internal Builder()
    {
    }

    public BalanceChangeInformRequest Build()
    {
      return this.instance;
    }

    public Builder SetWalletId(String value)
    {
      this.instance.WalletId = value;
      return this;
    }

    public Builder SetBalanceChangeId(String value)
    {
      this.instance.BalanceChangeId = value;
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

    public Builder SetSource(BalanceChangeSourceBase value)
    {
      this.instance.Source = value;
      return this;
    }

    public Builder SetStatus(BalanceChangeStatus value)
    {
      this.instance.Status = value;
      return this;
    }
  }
}
