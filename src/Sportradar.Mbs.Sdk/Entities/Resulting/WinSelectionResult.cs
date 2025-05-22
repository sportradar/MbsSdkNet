using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Resulting;

public class WinSelectionResult : SelectionResultBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "win";

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("voidFactor")]
  public decimal? VoidFactor { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("deadHeatFactor")]
  public decimal? DeadHeatFactor { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly WinSelectionResult instance = new WinSelectionResult();

    internal Builder()
    {
    }

    public WinSelectionResult Build()
    {
      return this.instance;
    }

    public Builder SetVoidFactor(decimal value)
    {
      this.instance.VoidFactor = value;
      return this;
    }

    public Builder SetDeadHeatFactor(decimal value)
    {
      this.instance.DeadHeatFactor = value;
      return this;
    }
  }
}
