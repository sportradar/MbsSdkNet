using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Autocashoutcancellation;

public class TicketAutoCashoutCancelDetails : AutoCashoutCancelDetailsBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket";

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
    private readonly TicketAutoCashoutCancelDetails instance = new TicketAutoCashoutCancelDetails();

    internal Builder()
    {
    }

    public TicketAutoCashoutCancelDetails Build()
    {
      return this.instance;
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
