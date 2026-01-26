using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Autocashoutcancellation;

public class BetAutoCashoutCancelDetails : AutoCashoutCancelDetailsBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "bet";

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
    private readonly BetAutoCashoutCancelDetails instance = new BetAutoCashoutCancelDetails();

    internal Builder()
    {
    }

    public BetAutoCashoutCancelDetails Build()
    {
      return this.instance;
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
