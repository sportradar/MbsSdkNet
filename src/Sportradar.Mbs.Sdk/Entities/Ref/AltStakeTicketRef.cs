using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Ref;

public class AltStakeTicketRef : TicketRefBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "alt-stake";

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
    private readonly AltStakeTicketRef instance = new AltStakeTicketRef();

    internal Builder()
    {
    }

    public AltStakeTicketRef Build()
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
