using Sportradar.Mbs.Sdk.Entities.Autocashout;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class AutoCashoutRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "auto-cashout";

  [JsonPropertyName("autoCashoutId")]
  public String? AutoCashoutId { get; set; }

  [JsonPropertyName("details")]
  public AutoCashoutDetailsBase? Details { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly AutoCashoutRequest instance = new AutoCashoutRequest();

    internal Builder()
    {
    }

    public AutoCashoutRequest Build()
    {
      return this.instance;
    }

    public Builder SetAutoCashoutId(String value)
    {
      this.instance.AutoCashoutId = value;
      return this;
    }

    public Builder SetDetails(AutoCashoutDetailsBase value)
    {
      this.instance.Details = value;
      return this;
    }
  }
}
