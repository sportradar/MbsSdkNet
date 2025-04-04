using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class CashoutInformRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "cashout-inform";

  [JsonPropertyName("validation")]
  public CashoutInformValidation? Validation { get; set; }

  [JsonPropertyName("cashout")]
  public CashoutRequest? Cashout { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CashoutInformRequest instance = new CashoutInformRequest();

    internal Builder()
    {
    }

    public CashoutInformRequest Build()
    {
      return this.instance;
    }

    public Builder SetValidation(CashoutInformValidation value)
    {
      this.instance.Validation = value;
      return this;
    }

    public Builder SetCashout(CashoutRequest value)
    {
      this.instance.Cashout = value;
      return this;
    }
  }
}
