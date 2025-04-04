using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

public class MaxStakeResponse : ContentResponseBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "max-stake-reply";

  [JsonPropertyName("code")]
  public int Code { get; set; }

  [JsonPropertyName("signature")]
  public String? Signature { get; set; }

  [JsonPropertyName("bets")]
  public Bet[]? Bets { get; set; }

  [JsonPropertyName("message")]
  public String? Message { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly MaxStakeResponse instance = new MaxStakeResponse();

    internal Builder()
    {
    }

    public MaxStakeResponse Build()
    {
      return this.instance;
    }

    public Builder SetCode(int value)
    {
      this.instance.Code = value;
      return this;
    }

    public Builder SetSignature(String value)
    {
      this.instance.Signature = value;
      return this;
    }

    public Builder SetBets(params Bet[] value)
    {
      this.instance.Bets = value;
      return this;
    }

    public Builder SetBets<T>(IList<T> value) where T : Bet
    {
      Bet[] arr = value.ToArray();
      return SetBets(arr);
    }

    public Builder SetMessage(String value)
    {
      this.instance.Message = value;
      return this;
    }
  }
}
