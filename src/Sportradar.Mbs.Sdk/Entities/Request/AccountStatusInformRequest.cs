using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class AccountStatusInformRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "account-status-inform";

  [JsonPropertyName("duration")]
  public AccountStatusChangeDuration? Duration { get; set; }

  [JsonPropertyName("reason")]
  public String? Reason { get; set; }

  [JsonPropertyName("initiator")]
  public AccountStatusChangeInitiator? Initiator { get; set; }

  [JsonPropertyName("endCustomer")]
  public EndCustomer? EndCustomer { get; set; }

  [JsonPropertyName("periodStartUtc")]
  public long PeriodStartUtc { get; set; }

  [JsonPropertyName("status")]
  public AccountStatus? Status { get; set; }

  [JsonPropertyName("periodEndUtc")]
  public long? PeriodEndUtc { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly AccountStatusInformRequest instance = new AccountStatusInformRequest();

    internal Builder()
    {
    }

    public AccountStatusInformRequest Build()
    {
      return this.instance;
    }

    public Builder SetDuration(AccountStatusChangeDuration value)
    {
      this.instance.Duration = value;
      return this;
    }

    public Builder SetReason(String value)
    {
      this.instance.Reason = value;
      return this;
    }

    public Builder SetInitiator(AccountStatusChangeInitiator value)
    {
      this.instance.Initiator = value;
      return this;
    }

    public Builder SetEndCustomer(EndCustomer value)
    {
      this.instance.EndCustomer = value;
      return this;
    }

    public Builder SetPeriodStartUtc(long value)
    {
      this.instance.PeriodStartUtc = value;
      return this;
    }

    public Builder SetStatus(AccountStatus value)
    {
      this.instance.Status = value;
      return this;
    }

    public Builder SetPeriodEndUtc(long value)
    {
      this.instance.PeriodEndUtc = value;
      return this;
    }
  }
}
