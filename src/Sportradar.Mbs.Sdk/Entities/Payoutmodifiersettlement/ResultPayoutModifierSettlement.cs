using Sportradar.Mbs.Sdk.Entities.Resulting;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Payoutmodifiersettlement;

public class ResultPayoutModifierSettlement : PayoutModifierSettlementBase
{
  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "result";

  [JsonPropertyName("result")]
  public SelectionResultBase? Result { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly ResultPayoutModifierSettlement instance = new ResultPayoutModifierSettlement();

    internal Builder()
    {
    }

    public ResultPayoutModifierSettlement Build()
    {
      return this.instance;
    }

    public Builder SetResult(SelectionResultBase value)
    {
      this.instance.Result = value;
      return this;
    }
  }
}