using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Accountlimit;

public class LossAccountLimit : AccountLimitBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "loss";

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
    private readonly LossAccountLimit instance = new LossAccountLimit();

    internal Builder()
    {
    }

    public LossAccountLimit Build()
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
