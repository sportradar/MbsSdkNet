using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class TicketAckRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket-ack";

  [JsonPropertyName("acknowledged")]
  public bool Acknowledged { get; set; }

  [JsonPropertyName("ticketSignature")]
  public String? TicketSignature { get; set; }

  [JsonPropertyName("ticketId")]
  public String? TicketId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly TicketAckRequest instance = new TicketAckRequest();

    internal Builder()
    {
    }

    public TicketAckRequest Build()
    {
      return this.instance;
    }

    public Builder SetAcknowledged(bool value)
    {
      this.instance.Acknowledged = value;
      return this;
    }

    public Builder SetTicketSignature(String value)
    {
      this.instance.TicketSignature = value;
      return this;
    }

    public Builder SetTicketId(String value)
    {
      this.instance.TicketId = value;
      return this;
    }
  }
}
