using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Probability;

public class WinSelectionProbability : SelectionProbabilityBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "win";

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("win")]
  public decimal? Win { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly WinSelectionProbability instance = new WinSelectionProbability();

    internal Builder()
    {
    }

    public WinSelectionProbability Build()
    {
      return this.instance;
    }

    public Builder SetWin(decimal value)
    {
      this.instance.Win = value;
      return this;
    }
  }
}
