using Sportradar.Mbs.Sdk.Entities.Payout;
using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Autocashoutthreshold;

public class StopLossAutoCashoutThreshold : AutoCashoutThresholdBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "stop-loss";

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("percentage")]
  public decimal? Percentage { get; set; }

  [JsonPropertyName("payout")]
  public PayoutBase[]? Payout { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly StopLossAutoCashoutThreshold instance = new StopLossAutoCashoutThreshold();

    internal Builder()
    {
    }

    public StopLossAutoCashoutThreshold Build()
    {
      return this.instance;
    }

    public Builder SetPercentage(decimal value)
    {
      this.instance.Percentage = value;
      return this;
    }

    public Builder SetPayout(params PayoutBase[] value)
    {
      this.instance.Payout = value;
      return this;
    }

    public Builder SetPayout<T>(IList<T> value) where T : PayoutBase
    {
      PayoutBase[] arr = value.ToArray();
      return SetPayout(arr);
    }
  }
}
