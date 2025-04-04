using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Accountlimit;

public class DepositAccountLimit : AccountLimitBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "deposit";

  [JsonPropertyName("period")]
  public AccountLimitPeriod? Period { get; set; }

  [JsonPropertyName("amount")]
  public Amount? Amount { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly DepositAccountLimit instance = new DepositAccountLimit();

    internal Builder()
    {
    }

    public DepositAccountLimit Build()
    {
      return this.instance;
    }

    public Builder SetPeriod(AccountLimitPeriod value)
    {
      this.instance.Period = value;
      return this;
    }

    public Builder SetAmount(Amount value)
    {
      this.instance.Amount = value;
      return this;
    }
  }
}
