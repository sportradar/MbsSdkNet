using Sportradar.Mbs.Sdk.Entities.Autocashoutcancellation;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class AutoCashoutCancelRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "auto-cashout-cancel";

  [JsonPropertyName("details")]
  public AutoCashoutCancelDetailsBase? Details { get; set; }

  [JsonPropertyName("cancellationId")]
  public String? CancellationId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly AutoCashoutCancelRequest instance = new AutoCashoutCancelRequest();

    internal Builder()
    {
    }

    public AutoCashoutCancelRequest Build()
    {
      return this.instance;
    }

    public Builder SetDetails(AutoCashoutCancelDetailsBase value)
    {
      this.instance.Details = value;
      return this;
    }

    public Builder SetCancellationId(String value)
    {
      this.instance.CancellationId = value;
      return this;
    }
  }
}
