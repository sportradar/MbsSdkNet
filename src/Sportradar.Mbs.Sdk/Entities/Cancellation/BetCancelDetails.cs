using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Cancellation;

public class BetCancelDetails : CancelDetailsBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "bet";

  [JsonPropertyName("code")]
  public int Code { get; set; }

  [JsonPropertyName("betId")]
  public String? BetId { get; set; }

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
    private readonly BetCancelDetails instance = new BetCancelDetails();

    internal Builder()
    {
    }

    public BetCancelDetails Build()
    {
      return this.instance;
    }

    public Builder SetCode(int value)
    {
      this.instance.Code = value;
      return this;
    }

    public Builder SetBetId(String value)
    {
      this.instance.BetId = value;
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
