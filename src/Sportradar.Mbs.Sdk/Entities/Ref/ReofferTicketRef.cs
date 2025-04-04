using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Ref;

public class ReofferTicketRef : TicketRefBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "reoffer";

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
    private readonly ReofferTicketRef instance = new ReofferTicketRef();

    internal Builder()
    {
    }

    public ReofferTicketRef Build()
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
