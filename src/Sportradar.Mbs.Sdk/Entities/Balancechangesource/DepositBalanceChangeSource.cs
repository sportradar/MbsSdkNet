using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Balancechangesource;

public class DepositBalanceChangeSource : BalanceChangeSourceBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "deposit";

  [JsonPropertyName("id")]
  public String? Id { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly DepositBalanceChangeSource instance = new DepositBalanceChangeSource();

    internal Builder()
    {
    }

    public DepositBalanceChangeSource Build()
    {
      return this.instance;
    }

    public Builder SetId(String value)
    {
      this.instance.Id = value;
      return this;
    }
  }
}
