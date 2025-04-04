using Sportradar.Mbs.Sdk.Entities.Channel;
using Sportradar.Mbs.Sdk.Entities.Payout;
using Sportradar.Mbs.Sdk.Entities.Ref;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class TicketContext
{

  [JsonPropertyName("walletId")]
  public String? WalletId { get; set; }

  [JsonPropertyName("ref")]
  public TicketRefBase? Ref { get; set; }

  [JsonPropertyName("channel")]
  public ChannelBase? Channel { get; set; }

  [JsonPropertyName("limitId")]
  public long LimitId { get; set; }

  [JsonPropertyName("payoutCap")]
  public PayoutBase[]? PayoutCap { get; set; }

  [JsonPropertyName("endCustomer")]
  public EndCustomer? EndCustomer { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly TicketContext instance = new TicketContext();

    internal Builder()
    {
    }

    public TicketContext Build()
    {
      return this.instance;
    }

    public Builder SetWalletId(String value)
    {
      this.instance.WalletId = value;
      return this;
    }

    public Builder SetRef(TicketRefBase value)
    {
      this.instance.Ref = value;
      return this;
    }

    public Builder SetChannel(ChannelBase value)
    {
      this.instance.Channel = value;
      return this;
    }

    public Builder SetLimitId(long value)
    {
      this.instance.LimitId = value;
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

    public Builder SetEndCustomer(EndCustomer value)
    {
      this.instance.EndCustomer = value;
      return this;
    }
  }
}
