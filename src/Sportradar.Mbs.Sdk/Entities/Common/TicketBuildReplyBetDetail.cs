using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class TicketBuildReplyBetDetail
{

  [JsonPropertyName("betId")]
  public String? BetId { get; set; }

  [JsonPropertyName("selectionDetails")]
  public TicketBuildReplySelectionDetail[]? SelectionDetails { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly TicketBuildReplyBetDetail instance = new TicketBuildReplyBetDetail();

    internal Builder()
    {
    }

    public TicketBuildReplyBetDetail Build()
    {
      return this.instance;
    }

    public Builder SetBetId(String value)
    {
      this.instance.BetId = value;
      return this;
    }

    public Builder SetSelectionDetails(params TicketBuildReplySelectionDetail[] value)
    {
      this.instance.SelectionDetails = value;
      return this;
    }

    public Builder SetSelectionDetails<T>(IList<T> value) where T : TicketBuildReplySelectionDetail
    {
      TicketBuildReplySelectionDetail[] arr = value.ToArray();
      return SetSelectionDetails(arr);
    }
  }
}
