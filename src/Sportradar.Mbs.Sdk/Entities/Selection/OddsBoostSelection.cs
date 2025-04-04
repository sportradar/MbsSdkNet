using Sportradar.Mbs.Sdk.Entities.Odds;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Selection;

public class OddsBoostSelection : SelectionBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "odds-boost";

  [JsonPropertyName("selection")]
  public SelectionBase? Selection { get; set; }

  [JsonPropertyName("odds")]
  public OddsBase? Odds { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly OddsBoostSelection instance = new OddsBoostSelection();

    internal Builder()
    {
    }

    public OddsBoostSelection Build()
    {
      return this.instance;
    }

    public Builder SetSelection(SelectionBase value)
    {
      this.instance.Selection = value;
      return this;
    }

    public Builder SetOdds(OddsBase value)
    {
      this.instance.Odds = value;
      return this;
    }
  }
}
