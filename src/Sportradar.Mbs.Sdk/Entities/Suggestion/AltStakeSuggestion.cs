using Sportradar.Mbs.Sdk.Entities.Stake;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Suggestion;

public class AltStakeSuggestion : SuggestionBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "alt-stake";

  [JsonPropertyName("stake")]
  public StakeBase[]? Stake { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly AltStakeSuggestion instance = new AltStakeSuggestion();

    internal Builder()
    {
    }

    public AltStakeSuggestion Build()
    {
      return this.instance;
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
