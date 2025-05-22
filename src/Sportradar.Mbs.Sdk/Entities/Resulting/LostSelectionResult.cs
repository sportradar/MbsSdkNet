using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Resulting;

public class LostSelectionResult : SelectionResultBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "lost";

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("voidFactor")]
  public decimal? VoidFactor { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly LostSelectionResult instance = new LostSelectionResult();

    internal Builder()
    {
    }

    public LostSelectionResult Build()
    {
      return this.instance;
    }

    public Builder SetVoidFactor(decimal value)
    {
      this.instance.VoidFactor = value;
      return this;
    }
  }
}
