using Sportradar.Mbs.Sdk.Entities.Settlement;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class ExtSettlementRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ext-settlement";

  [JsonPropertyName("details")]
  public ExtSettlementDetailsBase? Details { get; set; }

  [JsonPropertyName("settlementId")]
  public String? SettlementId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly ExtSettlementRequest instance = new ExtSettlementRequest();

    internal Builder()
    {
    }

    public ExtSettlementRequest Build()
    {
      return this.instance;
    }

    public Builder SetDetails(ExtSettlementDetailsBase value)
    {
      this.instance.Details = value;
      return this;
    }

    public Builder SetSettlementId(String value)
    {
      this.instance.SettlementId = value;
      return this;
    }
  }
}
