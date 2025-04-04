using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class MaxStakeRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "max-stake";

  [JsonPropertyName("ticket")]
  public TicketRequest? Ticket { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly MaxStakeRequest instance = new MaxStakeRequest();

    internal Builder()
    {
    }

    public MaxStakeRequest Build()
    {
      return this.instance;
    }

    public Builder SetTicket(TicketRequest value)
    {
      this.instance.Ticket = value;
      return this;
    }
  }
}
