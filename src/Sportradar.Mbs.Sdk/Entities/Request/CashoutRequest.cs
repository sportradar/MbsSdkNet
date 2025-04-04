using Sportradar.Mbs.Sdk.Entities.Cashout;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class CashoutRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "cashout";

  [JsonPropertyName("cashoutId")]
  public String? CashoutId { get; set; }

  [JsonPropertyName("details")]
  public CashoutDetailsBase? Details { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CashoutRequest instance = new CashoutRequest();

    internal Builder()
    {
    }

    public CashoutRequest Build()
    {
      return this.instance;
    }

    public Builder SetCashoutId(String value)
    {
      this.instance.CashoutId = value;
      return this;
    }

    public Builder SetDetails(CashoutDetailsBase value)
    {
      this.instance.Details = value;
      return this;
    }
  }
}
