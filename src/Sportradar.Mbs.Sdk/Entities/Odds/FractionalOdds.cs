using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Odds;

public class FractionalOdds : OddsBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "fractional";

  [JsonConverter(typeof(LongJsonConverter))]
  [JsonPropertyName("numerator")]
  public long? Numerator { get; set; }

  [JsonConverter(typeof(LongJsonConverter))]
  [JsonPropertyName("denominator")]
  public long? Denominator { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly FractionalOdds instance = new FractionalOdds();

    internal Builder()
    {
    }

    public FractionalOdds Build()
    {
      return this.instance;
    }

    public Builder SetNumerator(long value)
    {
      this.instance.Numerator = value;
      return this;
    }

    public Builder SetDenominator(long value)
    {
      this.instance.Denominator = value;
      return this;
    }
  }
}
