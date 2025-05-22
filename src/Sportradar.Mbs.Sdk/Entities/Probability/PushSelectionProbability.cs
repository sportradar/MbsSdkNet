using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Probability;

public class PushSelectionProbability : SelectionProbabilityBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "push";

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("halfWin")]
  public decimal? HalfWin { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("halfLose")]
  public decimal? HalfLose { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("win")]
  public decimal? Win { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("refund")]
  public decimal? Refund { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly PushSelectionProbability instance = new PushSelectionProbability();

    internal Builder()
    {
    }

    public PushSelectionProbability Build()
    {
      return this.instance;
    }

    public Builder SetHalfWin(decimal value)
    {
      this.instance.HalfWin = value;
      return this;
    }

    public Builder SetHalfLose(decimal value)
    {
      this.instance.HalfLose = value;
      return this;
    }

    public Builder SetWin(decimal value)
    {
      this.instance.Win = value;
      return this;
    }

    public Builder SetRefund(decimal value)
    {
      this.instance.Refund = value;
      return this;
    }
  }
}
