using Sportradar.Mbs.Sdk.Entities.Accountlimit;
using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class AccountLimitReachedInformRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "account-limit-reached-inform";

  [JsonPropertyName("endCustomer")]
  public EndCustomer? EndCustomer { get; set; }

  [JsonPropertyName("reachedLimit")]
  public AccountLimitType? ReachedLimit { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly AccountLimitReachedInformRequest instance = new AccountLimitReachedInformRequest();

    internal Builder()
    {
    }

    public AccountLimitReachedInformRequest Build()
    {
      return this.instance;
    }

    public Builder SetEndCustomer(EndCustomer value)
    {
      this.instance.EndCustomer = value;
      return this;
    }

    public Builder SetReachedLimit(AccountLimitType value)
    {
      this.instance.ReachedLimit = value;
      return this;
    }
  }
}
