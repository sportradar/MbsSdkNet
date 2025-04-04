using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Stake;

public class BonusStake : StakeBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "bonus";

  [JsonPropertyName("mode")]
  public StakeMode? Mode { get; set; }

  [JsonPropertyName("traceId")]
  public String? TraceId { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("amount")]
  public decimal? Amount { get; set; }

  [JsonPropertyName("currency")]
  public String? Currency { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly BonusStake instance = new BonusStake();

    internal Builder()
    {
    }

    public BonusStake Build()
    {
      return this.instance;
    }

    public Builder SetMode(StakeMode value)
    {
      this.instance.Mode = value;
      return this;
    }

    public Builder SetTraceId(String value)
    {
      this.instance.TraceId = value;
      return this;
    }

    public Builder SetAmount(decimal value)
    {
      this.instance.Amount = value;
      return this;
    }

    public Builder SetCurrency(String value)
    {
      this.instance.Currency = value;
      return this;
    }
  }
}
