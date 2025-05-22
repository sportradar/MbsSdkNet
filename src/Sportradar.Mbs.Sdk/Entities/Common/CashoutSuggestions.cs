using Sportradar.Mbs.Sdk.Entities.Payout;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class CashoutSuggestions
{

  [JsonPropertyName("fairCashout")]
  public PayoutBase[]? FairCashout { get; set; }

  [JsonPropertyName("cashoutId")]
  public String? CashoutId { get; set; }

  [JsonPropertyName("cashoutType")]
  public String? CashoutType { get; set; }

  [JsonPropertyName("maxPayout")]
  public PayoutBase[]? MaxPayout { get; set; }

  [JsonPropertyName("cashout")]
  public PayoutBase[]? Cashout { get; set; }

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

    public Builder SetFairCashout(params PayoutBase[] value)
    {
      this.instance.FairCashout = value;
      return this;
    }

    public Builder SetFairCashout<T>(IList<T> value) where T : PayoutBase
    {
      PayoutBase[] arr = value.ToArray();
      return SetFairCashout(arr);
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

    public Builder SetMaxPayout(params PayoutBase[] value)
    {
      this.instance.MaxPayout = value;
      return this;
    }

    public Builder SetMaxPayout<T>(IList<T> value) where T : PayoutBase
    {
      PayoutBase[] arr = value.ToArray();
      return SetMaxPayout(arr);
    }

    public Builder SetCashout(params PayoutBase[] value)
    {
      this.instance.Cashout = value;
      return this;
    }

    public Builder SetCashout<T>(IList<T> value) where T : PayoutBase
    {
      PayoutBase[] arr = value.ToArray();
      return SetCashout(arr);
    }
  }
}
