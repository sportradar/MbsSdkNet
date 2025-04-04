using Sportradar.Mbs.Sdk.Entities.Payout;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class BetContext
{

  [JsonPropertyName("oddsChange")]
  public OddsChange? OddsChange { get; set; }

  [JsonPropertyName("payoutCap")]
  public PayoutBase[]? PayoutCap { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly BetContext instance = new BetContext();

    internal Builder()
    {
    }

    public BetContext Build()
    {
      return this.instance;
    }

    public Builder SetOddsChange(OddsChange value)
    {
      this.instance.OddsChange = value;
      return this;
    }

    public Builder SetPayoutCap(params PayoutBase[] value)
    {
      this.instance.PayoutCap = value;
      return this;
    }

    public Builder SetPayoutCap<T>(IList<T> value) where T : PayoutBase
    {
      PayoutBase[] arr = value.ToArray();
      return SetPayoutCap(arr);
    }
  }
}
