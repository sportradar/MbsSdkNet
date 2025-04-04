using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class AccountInterventionInformRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "account-intervention-inform";

  [JsonPropertyName("method")]
  public InterventionMethod? Method { get; set; }

  [JsonPropertyName("modelInitiated")]
  public bool ModelInitiated { get; set; }

  [JsonPropertyName("endCustomer")]
  public EndCustomer? EndCustomer { get; set; }

  [JsonPropertyName("comment")]
  public String? Comment { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly AccountInterventionInformRequest instance = new AccountInterventionInformRequest();

    internal Builder()
    {
    }

    public AccountInterventionInformRequest Build()
    {
      return this.instance;
    }

    public Builder SetMethod(InterventionMethod value)
    {
      this.instance.Method = value;
      return this;
    }

    public Builder SetModelInitiated(bool value)
    {
      this.instance.ModelInitiated = value;
      return this;
    }

    public Builder SetEndCustomer(EndCustomer value)
    {
      this.instance.EndCustomer = value;
      return this;
    }

    public Builder SetComment(String value)
    {
      this.instance.Comment = value;
      return this;
    }
  }
}
