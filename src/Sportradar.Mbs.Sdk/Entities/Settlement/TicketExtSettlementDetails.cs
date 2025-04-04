using Sportradar.Mbs.Sdk.Entities.Payout;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Settlement;

public class TicketExtSettlementDetails : ExtSettlementDetailsBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket";

  [JsonPropertyName("payout")]
  public PayoutBase[]? Payout { get; set; }

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
    private readonly TicketExtSettlementDetails instance = new TicketExtSettlementDetails();

    internal Builder()
    {
    }

    public TicketExtSettlementDetails Build()
    {
      return this.instance;
    }

    public Builder SetPayout(params PayoutBase[] value)
    {
      this.instance.Payout = value;
      return this;
    }

    public Builder SetPayout<T>(IList<T> value) where T : PayoutBase
    {
      PayoutBase[] arr = value.ToArray();
      return SetPayout(arr);
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
