using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Odds;

public class DecimalOdds : OddsBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "decimal";

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("value")]
  public decimal? Value { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly DecimalOdds instance = new DecimalOdds();

    internal Builder()
    {
    }

    public DecimalOdds Build()
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
