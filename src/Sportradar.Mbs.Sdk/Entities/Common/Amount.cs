using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class Amount
{

  [JsonPropertyName("currency")]
  public String? Currency { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("value")]
  public decimal? Value { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly Amount instance = new Amount();

    internal Builder()
    {
    }

    public Amount Build()
    {
      return this.instance;
    }

    public Builder SetCurrency(String value)
    {
      this.instance.Currency = value;
      return this;
    }

    public Builder SetValue(decimal value)
    {
      this.instance.Value = value;
      return this;
    }
  }
}
