using Sportradar.Mbs.Sdk.Entities.Suggestion;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class BetDetail
{

  [JsonPropertyName("code")]
  public int Code { get; set; }

  [JsonPropertyName("suggestion")]
  public SuggestionBase? Suggestion { get; set; }

  [JsonPropertyName("betId")]
  public String? BetId { get; set; }

  [JsonPropertyName("selectionDetails")]
  public SelectionDetail[]? SelectionDetails { get; set; }

  [JsonPropertyName("message")]
  public String? Message { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly BetDetail instance = new BetDetail();

    internal Builder()
    {
    }

    public BetDetail Build()
    {
      return this.instance;
    }

    public Builder SetCode(int value)
    {
      this.instance.Code = value;
      return this;
    }

    public Builder SetSuggestion(SuggestionBase value)
    {
      this.instance.Suggestion = value;
      return this;
    }

    public Builder SetBetId(String value)
    {
      this.instance.BetId = value;
      return this;
    }

    public Builder SetSelectionDetails(params SelectionDetail[] value)
    {
      this.instance.SelectionDetails = value;
      return this;
    }

    public Builder SetSelectionDetails<T>(IList<T> value) where T : SelectionDetail
    {
      SelectionDetail[] arr = value.ToArray();
      return SetSelectionDetails(arr);
    }

    public Builder SetMessage(String value)
    {
      this.instance.Message = value;
      return this;
    }
  }
}
