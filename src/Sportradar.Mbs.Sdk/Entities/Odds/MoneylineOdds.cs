using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Odds;

public class MoneylineOdds : OddsBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "moneyline";

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("value")]
  public decimal? Value { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly MoneylineOdds instance = new MoneylineOdds();

    internal Builder()
    {
    }

    public MoneylineOdds Build()
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
