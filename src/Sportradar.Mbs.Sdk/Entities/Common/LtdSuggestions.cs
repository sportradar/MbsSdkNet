using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class LtdSuggestions
{

  [JsonPropertyName("suggestedLtd")]
  public int? SuggestedLtd { get; set; }

  [JsonPropertyName("modelSuggestedLtd")]
  public ModelSuggestedLtd? ModelSuggestedLtd { get; set; }

  [JsonPropertyName("accountLbsLtdOffset")]
  public int? AccountLbsLtdOffset { get; set; }

  [JsonPropertyName("configuredLtd")]
  public int? ConfiguredLtd { get; set; }

  [JsonPropertyName("appliedLtd")]
  public int? AppliedLtd { get; set; }

  [JsonPropertyName("liveSelectionLtdOffset")]
  public int? LiveSelectionLtdOffset { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly LtdSuggestions instance = new LtdSuggestions();

    internal Builder()
    {
    }

    public LtdSuggestions Build()
    {
      return this.instance;
    }

    public Builder SetSuggestedLtd(int value)
    {
      this.instance.SuggestedLtd = value;
      return this;
    }

    public Builder SetModelSuggestedLtd(ModelSuggestedLtd value)
    {
      this.instance.ModelSuggestedLtd = value;
      return this;
    }

    public Builder SetAccountLbsLtdOffset(int value)
    {
      this.instance.AccountLbsLtdOffset = value;
      return this;
    }

    public Builder SetConfiguredLtd(int value)
    {
      this.instance.ConfiguredLtd = value;
      return this;
    }

    public Builder SetAppliedLtd(int value)
    {
      this.instance.AppliedLtd = value;
      return this;
    }

    public Builder SetLiveSelectionLtdOffset(int value)
    {
      this.instance.LiveSelectionLtdOffset = value;
      return this;
    }
  }
}
