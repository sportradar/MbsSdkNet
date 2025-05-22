using Sportradar.Mbs.Sdk.Entities.Probability;
using Sportradar.Mbs.Sdk.Entities.Resulting;
using Sportradar.Mbs.Sdk.Entities.Selection;
using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class TicketBuildReplySelectionDetail
{

  [JsonPropertyName("suggestedLtd")]
  public int? SuggestedLtd { get; set; }

  [JsonPropertyName("selection")]
  public SelectionBase? Selection { get; set; }

  [JsonPropertyName("currentResult")]
  public SelectionResultBase? CurrentResult { get; set; }

  [JsonPropertyName("configuredLtd")]
  public int? ConfiguredLtd { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("appliedMarketFactor")]
  public decimal? AppliedMarketFactor { get; set; }

  [JsonPropertyName("currentProbability")]
  public SelectionProbabilityBase? CurrentProbability { get; set; }

  [JsonPropertyName("appliedEventRating")]
  public int? AppliedEventRating { get; set; }

  [JsonPropertyName("suggestedEventRating")]
  public int? SuggestedEventRating { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly TicketBuildReplySelectionDetail instance = new TicketBuildReplySelectionDetail();

    internal Builder()
    {
    }

    public TicketBuildReplySelectionDetail Build()
    {
      return this.instance;
    }

    public Builder SetSuggestedLtd(int value)
    {
      this.instance.SuggestedLtd = value;
      return this;
    }

    public Builder SetSelection(SelectionBase value)
    {
      this.instance.Selection = value;
      return this;
    }

    public Builder SetCurrentResult(SelectionResultBase value)
    {
      this.instance.CurrentResult = value;
      return this;
    }

    public Builder SetConfiguredLtd(int value)
    {
      this.instance.ConfiguredLtd = value;
      return this;
    }

    public Builder SetAppliedMarketFactor(decimal value)
    {
      this.instance.AppliedMarketFactor = value;
      return this;
    }

    public Builder SetCurrentProbability(SelectionProbabilityBase value)
    {
      this.instance.CurrentProbability = value;
      return this;
    }

    public Builder SetAppliedEventRating(int value)
    {
      this.instance.AppliedEventRating = value;
      return this;
    }

    public Builder SetSuggestedEventRating(int value)
    {
      this.instance.SuggestedEventRating = value;
      return this;
    }
  }
}
