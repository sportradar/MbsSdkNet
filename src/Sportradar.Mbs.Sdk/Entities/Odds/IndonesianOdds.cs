using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Odds;

public class IndonesianOdds : OddsBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "indonesian";

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("value")]
  public decimal? Value { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly IndonesianOdds instance = new IndonesianOdds();

    internal Builder()
    {
    }

    public IndonesianOdds Build()
    {
      return this.instance;
    }

    public Builder SetValue(decimal value)
    {
      this.instance.Value = value;
      return this;
    }
  }
}
