using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class ExtSettlementAckRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ext-settlement-ack";

  [JsonPropertyName("acknowledged")]
  public bool Acknowledged { get; set; }

  [JsonPropertyName("settlementSignature")]
  public String? SettlementSignature { get; set; }

  [JsonPropertyName("settlementId")]
  public String? SettlementId { get; set; }

  [JsonPropertyName("ticketId")]
  public String? TicketId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly ExtSettlementAckRequest instance = new ExtSettlementAckRequest();

    internal Builder()
    {
    }

    public ExtSettlementAckRequest Build()
    {
      return this.instance;
    }

    public Builder SetAcknowledged(bool value)
    {
      this.instance.Acknowledged = value;
      return this;
    }

    public Builder SetSettlementSignature(String value)
    {
      this.instance.SettlementSignature = value;
      return this;
    }

    public Builder SetSettlementId(String value)
    {
      this.instance.SettlementId = value;
      return this;
    }

    public Builder SetTicketId(String value)
    {
      this.instance.TicketId = value;
      return this;
    }
  }
}
