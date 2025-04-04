using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

public class TicketAckResponse : ContentResponseBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket-ack-reply";

  [JsonPropertyName("code")]
  public int Code { get; set; }

  [JsonPropertyName("signature")]
  public String? Signature { get; set; }

  [JsonPropertyName("message")]
  public String? Message { get; set; }

  [JsonPropertyName("ticketId")]
  public String? TicketId { get; set; }

  [JsonPropertyName("status")]
  public AcceptanceStatus? Status { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly TicketAckResponse instance = new TicketAckResponse();

    internal Builder()
    {
    }

    public TicketAckResponse Build()
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

    public Builder SetTicketId(String value)
    {
      this.instance.TicketId = value;
      return this;
    }

    public Builder SetStatus(AcceptanceStatus value)
    {
      this.instance.Status = value;
      return this;
    }
  }
}
