using Sportradar.Mbs.Sdk.Entities.Selection;
using Sportradar.Mbs.Sdk.Entities.Stake;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class Bet
{

  [JsonPropertyName("stake")]
  public StakeBase[]? Stake { get; set; }

  [JsonPropertyName("selections")]
  public SelectionBase[]? Selections { get; set; }

  [JsonPropertyName("betId")]
  public String? BetId { get; set; }

  [JsonPropertyName("context")]
  public BetContext? Context { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly Bet instance = new Bet();

    internal Builder()
    {
    }

    public Bet Build()
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

    public Builder SetSelections(params SelectionBase[] value)
    {
      this.instance.Selections = value;
      return this;
    }

    public Builder SetSelections<T>(IList<T> value) where T : SelectionBase
    {
      SelectionBase[] arr = value.ToArray();
      return SetSelections(arr);
    }

    public Builder SetBetId(String value)
    {
      this.instance.BetId = value;
      return this;
    }

    public Builder SetContext(BetContext value)
    {
      this.instance.Context = value;
      return this;
    }
  }
}
