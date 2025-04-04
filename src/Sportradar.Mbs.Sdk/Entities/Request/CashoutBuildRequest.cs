using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class CashoutBuildRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "cashout-build";

  [JsonPropertyName("cashout")]
  public CashoutRequest? Cashout { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CashoutBuildRequest instance = new CashoutBuildRequest();

    internal Builder()
    {
    }

    public CashoutBuildRequest Build()
    {
      return this.instance;
    }

    public Builder SetCashout(CashoutRequest value)
    {
      this.instance.Cashout = value;
      return this;
    }
  }
}
