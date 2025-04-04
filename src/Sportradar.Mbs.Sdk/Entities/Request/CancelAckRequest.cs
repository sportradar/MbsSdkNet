using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class CancelAckRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "cancel-ack";

  [JsonPropertyName("cancellationSignature")]
  public String? CancellationSignature { get; set; }

  [JsonPropertyName("acknowledged")]
  public bool Acknowledged { get; set; }

  [JsonPropertyName("cancellationId")]
  public String? CancellationId { get; set; }

  [JsonPropertyName("ticketId")]
  public String? TicketId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CancelAckRequest instance = new CancelAckRequest();

    internal Builder()
    {
    }

    public CancelAckRequest Build()
    {
      return this.instance;
    }

    public Builder SetCancellationSignature(String value)
    {
      this.instance.CancellationSignature = value;
      return this;
    }

    public Builder SetAcknowledged(bool value)
    {
      this.instance.Acknowledged = value;
      return this;
    }

    public Builder SetCancellationId(String value)
    {
      this.instance.CancellationId = value;
      return this;
    }

    public Builder SetTicketId(String value)
    {
      this.instance.TicketId = value;
      return this;
    }
  }
}
