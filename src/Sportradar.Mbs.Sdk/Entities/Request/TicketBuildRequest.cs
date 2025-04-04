using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class TicketBuildRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket-build";

  [JsonPropertyName("ticket")]
  public TicketRequest? Ticket { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly TicketBuildRequest instance = new TicketBuildRequest();

    internal Builder()
    {
    }

    public TicketBuildRequest Build()
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
