using Sportradar.Mbs.Sdk.Entities.Stake;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Suggestion;

public class ReofferSuggestion : SuggestionBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "reoffer";

  [JsonPropertyName("mode")]
  public String? Mode { get; set; }

  [JsonPropertyName("stake")]
  public StakeBase[]? Stake { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly ReofferSuggestion instance = new ReofferSuggestion();

    internal Builder()
    {
    }

    public ReofferSuggestion Build()
    {
      return this.instance;
    }

    public Builder SetMode(String value)
    {
      this.instance.Mode = value;
      return this;
    }

    public Builder SetStake(params StakeBase[] value)
    {
      this.instance.Stake = value;
      return this;
    }

    public Builder SetStake<T>(IList<T> value) where T : StakeBase
    {
      StakeBase[] arr = value.ToArray();
      return SetStake(arr);
    }
  }
}
