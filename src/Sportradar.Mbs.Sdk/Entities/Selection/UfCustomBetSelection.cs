using Sportradar.Mbs.Sdk.Entities.Odds;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Selection;

public class UfCustomBetSelection : SelectionBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "uf-custom-bet";

  [JsonPropertyName("selections")]
  public UfSelection[]? Selections { get; set; }

  [JsonPropertyName("odds")]
  public OddsBase? Odds { get; set; }

  [JsonPropertyName("harmOddsApplied")]
  public bool? HarmOddsApplied { get; set; }

  [JsonPropertyName("useHarmOdds")]
  public bool UseHarmOdds { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly UfCustomBetSelection instance = new UfCustomBetSelection();

    internal Builder()
    {
    }

    public UfCustomBetSelection Build()
    {
      return this.instance;
    }

    public Builder SetSelections(params UfSelection[] value)
    {
      this.instance.Selections = value;
      return this;
    }

    public Builder SetSelections<T>(IList<T> value) where T : UfSelection
    {
      UfSelection[] arr = value.ToArray();
      return SetSelections(arr);
    }

    public Builder SetOdds(OddsBase value)
    {
      this.instance.Odds = value;
      return this;
    }

    public Builder SetHarmOddsApplied(bool value)
    {
      this.instance.HarmOddsApplied = value;
      return this;
    }

    public Builder SetUseHarmOdds(bool value)
    {
      this.instance.UseHarmOdds = value;
      return this;
    }
  }
}
