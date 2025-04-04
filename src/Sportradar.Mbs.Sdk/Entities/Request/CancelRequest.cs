using Sportradar.Mbs.Sdk.Entities.Cancellation;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class CancelRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "cancel";

  [JsonPropertyName("details")]
  public CancelDetailsBase? Details { get; set; }

  [JsonPropertyName("cancellationId")]
  public String? CancellationId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CancelRequest instance = new CancelRequest();

    internal Builder()
    {
    }

    public CancelRequest Build()
    {
      return this.instance;
    }

    public Builder SetDetails(CancelDetailsBase value)
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
