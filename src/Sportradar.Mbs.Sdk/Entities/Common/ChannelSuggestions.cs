using Sportradar.Mbs.Sdk.Entities.Channel;
using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class ChannelSuggestions
{

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("appliedConfidence")]
  public decimal? AppliedConfidence { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("suggestedConfidence")]
  public decimal? SuggestedConfidence { get; set; }

  [JsonPropertyName("channel")]
  public ChannelBase? Channel { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("suggestedLateBetScore")]
  public decimal? SuggestedLateBetScore { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly ChannelSuggestions instance = new ChannelSuggestions();

    internal Builder()
    {
    }

    public ChannelSuggestions Build()
    {
      return this.instance;
    }

    public Builder SetAppliedConfidence(decimal value)
    {
      this.instance.AppliedConfidence = value;
      return this;
    }

    public Builder SetSuggestedConfidence(decimal value)
    {
      this.instance.SuggestedConfidence = value;
      return this;
    }

    public Builder SetChannel(ChannelBase value)
    {
      this.instance.Channel = value;
      return this;
    }

    public Builder SetSuggestedLateBetScore(decimal value)
    {
      this.instance.SuggestedLateBetScore = value;
      return this;
    }
  }
}
