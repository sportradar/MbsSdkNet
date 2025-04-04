using Sportradar.Mbs.Sdk.Entities.Casinospin;
using Sportradar.Mbs.Sdk.Entities.Payout;
using Sportradar.Mbs.Sdk.Entities.Stake;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class CasinoSession
{

  [JsonPropertyName("stake")]
  public StakeBase[]? Stake { get; set; }

  [JsonPropertyName("game")]
  public CasinoGame? Game { get; set; }

  [JsonPropertyName("spins")]
  public CasinoSpinBase[]? Spins { get; set; }

  [JsonPropertyName("payout")]
  public PayoutBase[]? Payout { get; set; }

  [JsonPropertyName("id")]
  public String? Id { get; set; }

  [JsonPropertyName("startUtc")]
  public long? StartUtc { get; set; }

  [JsonPropertyName("endUtc")]
  public long? EndUtc { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CasinoSession instance = new CasinoSession();

    internal Builder()
    {
    }

    public CasinoSession Build()
    {
      return this.instance;
    }

    public Builder SetStake(params StakeBase[] value)
    {
      this.instance.Stake = value;
      return this;
    }

    public Builder SetStake<T>(IList<T> value) where T : StakeBase
    {
      StakeBase[] arr = value.ToArray();
      return SetStake(arr);
    }

    public Builder SetGame(CasinoGame value)
    {
      this.instance.Game = value;
      return this;
    }

    public Builder SetSpins(params CasinoSpinBase[] value)
    {
      this.instance.Spins = value;
      return this;
    }

    public Builder SetSpins<T>(IList<T> value) where T : CasinoSpinBase
    {
      CasinoSpinBase[] arr = value.ToArray();
      return SetSpins(arr);
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

    public Builder SetId(String value)
    {
      this.instance.Id = value;
      return this;
    }

    public Builder SetStartUtc(long value)
    {
      this.instance.StartUtc = value;
      return this;
    }

    public Builder SetEndUtc(long value)
    {
      this.instance.EndUtc = value;
      return this;
    }
  }
}
