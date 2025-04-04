using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Casinospin;

public class BonusCasinoSpin : CasinoSpinBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "bonus";

  [JsonPropertyName("count")]
  public int Count { get; set; }

  [JsonPropertyName("winningCount")]
  public int? WinningCount { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly BonusCasinoSpin instance = new BonusCasinoSpin();

    internal Builder()
    {
    }

    public BonusCasinoSpin Build()
    {
      return this.instance;
    }

    public Builder SetCount(int value)
    {
      this.instance.Count = value;
      return this;
    }

    public Builder SetWinningCount(int value)
    {
      this.instance.WinningCount = value;
      return this;
    }
  }
}
