using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class CashoutSuggestions
{

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("fairCashout")]
  public decimal? FairCashout { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("simpleCashout")]
  public decimal? SimpleCashout { get; set; }

  [JsonPropertyName("cashoutId")]
  public String? CashoutId { get; set; }

  [JsonPropertyName("cashoutType")]
  public String? CashoutType { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("maxWinCurrent")]
  public decimal? MaxWinCurrent { get; set; }

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("partialCashout")]
  public decimal? PartialCashout { get; set; }

  [JsonPropertyName("currency")]
  public String? Currency { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CashoutSuggestions instance = new CashoutSuggestions();

    internal Builder()
    {
    }

    public CashoutSuggestions Build()
    {
      return this.instance;
    }

    public Builder SetFairCashout(decimal value)
    {
      this.instance.FairCashout = value;
      return this;
    }

    public Builder SetSimpleCashout(decimal value)
    {
      this.instance.SimpleCashout = value;
      return this;
    }

    public Builder SetCashoutId(String value)
    {
      this.instance.CashoutId = value;
      return this;
    }

    public Builder SetCashoutType(String value)
    {
      this.instance.CashoutType = value;
      return this;
    }

    public Builder SetMaxWinCurrent(decimal value)
    {
      this.instance.MaxWinCurrent = value;
      return this;
    }

    public Builder SetPartialCashout(decimal value)
    {
      this.instance.PartialCashout = value;
      return this;
    }

    public Builder SetCurrency(String value)
    {
      this.instance.Currency = value;
      return this;
    }
  }
}
