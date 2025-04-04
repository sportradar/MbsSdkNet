using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class CashoutInformValidation
{

  [JsonPropertyName("code")]
  public int Code { get; set; }

  [JsonPropertyName("rejected")]
  public bool Rejected { get; set; }

  [JsonPropertyName("message")]
  public String? Message { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CashoutInformValidation instance = new CashoutInformValidation();

    internal Builder()
    {
    }

    public CashoutInformValidation Build()
    {
      return this.instance;
    }

    public Builder SetCode(int value)
    {
      this.instance.Code = value;
      return this;
    }

    public Builder SetRejected(bool value)
    {
      this.instance.Rejected = value;
      return this;
    }

    public Builder SetMessage(String value)
    {
      this.instance.Message = value;
      return this;
    }
  }
}
