using Sportradar.Mbs.Sdk.Entities.Payout;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Cashout;

public class TicketCashoutDetails : CashoutDetailsBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket";

  [JsonPropertyName("code")]
  public int Code { get; set; }

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
    private readonly TicketCashoutDetails instance = new TicketCashoutDetails();

    internal Builder()
    {
    }

    public TicketCashoutDetails Build()
    {
      return this.instance;
    }

    public Builder SetCode(int value)
    {
      this.instance.Code = value;
      return this;
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
