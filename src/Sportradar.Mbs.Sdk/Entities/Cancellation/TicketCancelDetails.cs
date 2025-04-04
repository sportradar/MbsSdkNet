using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Cancellation;

public class TicketCancelDetails : CancelDetailsBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket";

  [JsonPropertyName("code")]
  public int Code { get; set; }

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
    private readonly TicketCancelDetails instance = new TicketCancelDetails();

    internal Builder()
    {
    }

    public TicketCancelDetails Build()
    {
      return this.instance;
    }

    public Builder SetCode(int value)
    {
      this.instance.Code = value;
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
