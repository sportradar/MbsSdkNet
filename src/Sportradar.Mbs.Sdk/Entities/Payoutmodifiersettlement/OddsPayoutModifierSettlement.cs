using Sportradar.Mbs.Sdk.Entities.Odds;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Payoutmodifiersettlement;

public class OddsPayoutModifierSettlement : PayoutModifierSettlementBase
{
  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "odds";

  [JsonPropertyName("odds")]
  public OddsBase? Odds { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly OddsPayoutModifierSettlement instance = new OddsPayoutModifierSettlement();

    internal Builder()
    {
    }

    public OddsPayoutModifierSettlement Build()
    {
      return this.instance;
    }

    public Builder SetOdds(OddsBase value)
    {
      this.instance.Odds = value;
      return this;
    }
  }
}