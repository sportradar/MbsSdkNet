using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Payout;

public class WithheldPayout : PayoutBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "withheld";

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
    private readonly WithheldPayout instance = new WithheldPayout();

    internal Builder()
    {
    }

    public WithheldPayout Build()
    {
      return this.instance;
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
