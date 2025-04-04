using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

public class AccountLimitInformResponse : ContentResponseBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "account-limit-inform-reply";

  [JsonPropertyName("code")]
  public int Code { get; set; }

  [JsonPropertyName("signature")]
  public String? Signature { get; set; }

  [JsonPropertyName("message")]
  public String? Message { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly AccountLimitInformResponse instance = new AccountLimitInformResponse();

    internal Builder()
    {
    }

    public AccountLimitInformResponse Build()
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

    public Builder SetMessage(String value)
    {
      this.instance.Message = value;
      return this;
    }
  }
}
