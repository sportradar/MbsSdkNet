using Sportradar.Mbs.Sdk.Entities.Odds;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Selection;

public class ExtSelection : SelectionBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "external";

  [JsonPropertyName("expSettleTime")]
  public long ExpSettleTime { get; set; }

  [JsonPropertyName("odds")]
  public OddsBase? Odds { get; set; }

  [JsonPropertyName("event")]
  public String? Event { get; set; }

  [JsonPropertyName("outcome")]
  public String? Outcome { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly ExtSelection instance = new ExtSelection();

    internal Builder()
    {
    }

    public ExtSelection Build()
    {
      return this.instance;
    }

    public Builder SetExpSettleTime(long value)
    {
      this.instance.ExpSettleTime = value;
      return this;
    }

    public Builder SetOdds(OddsBase value)
    {
      this.instance.Odds = value;
      return this;
    }

    public Builder SetEvent(String value)
    {
      this.instance.Event = value;
      return this;
    }

    public Builder SetOutcome(String value)
    {
      this.instance.Outcome = value;
      return this;
    }
  }
}
