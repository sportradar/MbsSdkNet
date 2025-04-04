using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class CashoutAckRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "cashout-ack";

  [JsonPropertyName("acknowledged")]
  public bool Acknowledged { get; set; }

  [JsonPropertyName("cashoutId")]
  public String? CashoutId { get; set; }

  [JsonPropertyName("cashoutSignature")]
  public String? CashoutSignature { get; set; }

  [JsonPropertyName("ticketId")]
  public String? TicketId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CashoutAckRequest instance = new CashoutAckRequest();

    internal Builder()
    {
    }

    public CashoutAckRequest Build()
    {
      return this.instance;
    }

    public Builder SetAcknowledged(bool value)
    {
      this.instance.Acknowledged = value;
      return this;
    }

    public Builder SetCashoutId(String value)
    {
      this.instance.CashoutId = value;
      return this;
    }

    public Builder SetCashoutSignature(String value)
    {
      this.instance.CashoutSignature = value;
      return this;
    }

    public Builder SetTicketId(String value)
    {
      this.instance.TicketId = value;
      return this;
    }
  }
}
