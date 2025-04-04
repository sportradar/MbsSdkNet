using Sportradar.Mbs.Sdk.Entities.Accountlimit;
using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class AccountLimitInformRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "account-limit-inform";

  [JsonPropertyName("limit")]
  public AccountLimitBase? Limit { get; set; }

  [JsonPropertyName("endCustomer")]
  public EndCustomer? EndCustomer { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly AccountLimitInformRequest instance = new AccountLimitInformRequest();

    internal Builder()
    {
    }

    public AccountLimitInformRequest Build()
    {
      return this.instance;
    }

    public Builder SetLimit(AccountLimitBase value)
    {
      this.instance.Limit = value;
      return this;
    }

    public Builder SetEndCustomer(EndCustomer value)
    {
      this.instance.EndCustomer = value;
      return this;
    }
  }
}
