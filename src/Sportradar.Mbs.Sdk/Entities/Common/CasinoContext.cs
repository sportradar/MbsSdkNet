using Sportradar.Mbs.Sdk.Entities.Channel;
using Sportradar.Mbs.Sdk.Entities.Common;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class CasinoContext
{
  [JsonPropertyName("walletId")]
  public String? WalletId { get; set; }

  [JsonPropertyName("rates")]
  public ExchangeRate[]? Rates { get; set; }

  [JsonPropertyName("channel")]
  public ChannelBase? Channel { get; set; }

  [JsonPropertyName("endCustomer")]
  public EndCustomer? EndCustomer { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CasinoContext instance = new CasinoContext();

    internal Builder()
    {
    }

    public CasinoContext Build()
    {
      return this.instance;
    }

    public Builder SetWalletId(String value)
    {
      this.instance.WalletId = value;
      return this;
    }

    public Builder SetRates(params ExchangeRate[] value)
    {
      this.instance.Rates = value;
      return this;
    }

    public Builder SetRates<T>(IList<T> value) where T : ExchangeRate
    {
      ExchangeRate[] arr = value.ToArray();
      return SetRates(arr);
    }

    public Builder SetChannel(ChannelBase value)
    {
      this.instance.Channel = value;
      return this;
    }

    public Builder SetEndCustomer(EndCustomer value)
    {
      this.instance.EndCustomer = value;
      return this;
    }
  }
}