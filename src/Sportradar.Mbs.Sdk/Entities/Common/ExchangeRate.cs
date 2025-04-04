using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class ExchangeRate
{

  [JsonPropertyName("toCurrency")]
  public String? ToCurrency { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("rate")]
  public decimal? Rate { get; set; }

  [JsonPropertyName("fromCurrency")]
  public String? FromCurrency { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly ExchangeRate instance = new ExchangeRate();

    internal Builder()
    {
    }

    public ExchangeRate Build()
    {
      return this.instance;
    }

    public Builder SetToCurrency(String value)
    {
      this.instance.ToCurrency = value;
      return this;
    }

    public Builder SetRate(decimal value)
    {
      this.instance.Rate = value;
      return this;
    }

    public Builder SetFromCurrency(String value)
    {
      this.instance.FromCurrency = value;
      return this;
    }
  }
}
