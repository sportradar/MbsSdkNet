using Sportradar.Mbs.Sdk.Entities.Selection;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class TicketBuildReplySelectionDetail
{

  [JsonPropertyName("selection")]
  public SelectionBase? Selection { get; set; }

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

    public Builder SetSelection(SelectionBase value)
    {
      this.instance.Selection = value;
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
