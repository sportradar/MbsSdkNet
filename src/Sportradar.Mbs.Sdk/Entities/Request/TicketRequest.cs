using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class TicketRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket";

  [JsonPropertyName("context")]
  public TicketContext? Context { get; set; }

  [JsonPropertyName("bets")]
  public Bet[]? Bets { get; set; }

  [JsonPropertyName("ticketId")]
  public String? TicketId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly TicketRequest instance = new TicketRequest();

    internal Builder()
    {
    }

    public TicketRequest Build()
    {
      return this.instance;
    }

    public Builder SetContext(TicketContext value)
    {
      this.instance.Context = value;
      return this;
    }

    public Builder SetBets(params Bet[] value)
    {
      this.instance.Bets = value;
      return this;
    }

    public Builder SetBets<T>(IList<T> value) where T : Bet
    {
      Bet[] arr = value.ToArray();
      return SetBets(arr);
    }

    public Builder SetTicketId(String value)
    {
      this.instance.TicketId = value;
      return this;
    }
  }
}
