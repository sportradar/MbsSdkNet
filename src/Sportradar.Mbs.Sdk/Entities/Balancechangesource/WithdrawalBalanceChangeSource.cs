using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Balancechangesource;

public class WithdrawalBalanceChangeSource : BalanceChangeSourceBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "withdrawal";

  [JsonPropertyName("id")]
  public String? Id { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly WithdrawalBalanceChangeSource instance = new WithdrawalBalanceChangeSource();

    internal Builder()
    {
    }

    public WithdrawalBalanceChangeSource Build()
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
