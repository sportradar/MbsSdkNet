using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class CashoutPlacementRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "cashout-placement";

  [JsonPropertyName("cashout")]
  public CashoutRequest? Cashout { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CashoutPlacementRequest instance = new CashoutPlacementRequest();

    internal Builder()
    {
    }

    public CashoutPlacementRequest Build()
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
