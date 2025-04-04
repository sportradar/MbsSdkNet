using Sportradar.Mbs.Sdk.Entities.Odds;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Selection;

public class UfSelection : SelectionBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "uf";

  [JsonPropertyName("eventId")]
  public String? EventId { get; set; }

  [JsonPropertyName("productId")]
  public String? ProductId { get; set; }

  [JsonPropertyName("odds")]
  public OddsBase? Odds { get; set; }

  [JsonPropertyName("outcomeId")]
  public String? OutcomeId { get; set; }

  [JsonPropertyName("specifiers")]
  public String? Specifiers { get; set; }

  [JsonPropertyName("marketId")]
  public String? MarketId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly UfSelection instance = new UfSelection();

    internal Builder()
    {
    }

    public UfSelection Build()
    {
      return this.instance;
    }

    public Builder SetEventId(String value)
    {
      this.instance.EventId = value;
      return this;
    }

    public Builder SetProductId(String value)
    {
      this.instance.ProductId = value;
      return this;
    }

    public Builder SetOdds(OddsBase value)
    {
      this.instance.Odds = value;
      return this;
    }

    public Builder SetOutcomeId(String value)
    {
      this.instance.OutcomeId = value;
      return this;
    }

    public Builder SetSpecifiers(String value)
    {
      this.instance.Specifiers = value;
      return this;
    }

    public Builder SetMarketId(String value)
    {
      this.instance.MarketId = value;
      return this;
    }
  }
}
