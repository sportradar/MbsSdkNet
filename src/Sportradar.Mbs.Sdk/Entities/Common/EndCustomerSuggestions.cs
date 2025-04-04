using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class EndCustomerSuggestions
{

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("appliedConfidence")]
  public decimal? AppliedConfidence { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("suggestedConfidence")]
  public decimal? SuggestedConfidence { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("suggestedMarkerScore")]
  public decimal? SuggestedMarkerScore { get; set; }

  [JsonPropertyName("endCustomer")]
  public EndCustomer? EndCustomer { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("suggestedBotScore")]
  public decimal? SuggestedBotScore { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("suggestedLateBetScore")]
  public decimal? SuggestedLateBetScore { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly EndCustomerSuggestions instance = new EndCustomerSuggestions();

    internal Builder()
    {
    }

    public EndCustomerSuggestions Build()
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

    public Builder SetSuggestedMarkerScore(decimal value)
    {
      this.instance.SuggestedMarkerScore = value;
      return this;
    }

    public Builder SetEndCustomer(EndCustomer value)
    {
      this.instance.EndCustomer = value;
      return this;
    }

    public Builder SetSuggestedBotScore(decimal value)
    {
      this.instance.SuggestedBotScore = value;
      return this;
    }

    public Builder SetSuggestedLateBetScore(decimal value)
    {
      this.instance.SuggestedLateBetScore = value;
      return this;
    }
  }
}
