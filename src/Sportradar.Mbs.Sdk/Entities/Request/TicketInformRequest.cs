using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class TicketInformRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket-inform";

  [JsonPropertyName("ticket")]
  public TicketRequest? Ticket { get; set; }

  [JsonPropertyName("betValidations")]
  public BetValidation[]? BetValidations { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly TicketInformRequest instance = new TicketInformRequest();

    internal Builder()
    {
    }

    public TicketInformRequest Build()
    {
      return this.instance;
    }

    public Builder SetTicket(TicketRequest value)
    {
      this.instance.Ticket = value;
      return this;
    }

    public Builder SetBetValidations(params BetValidation[] value)
    {
      this.instance.BetValidations = value;
      return this;
    }

    public Builder SetBetValidations<T>(IList<T> value) where T : BetValidation
    {
      BetValidation[] arr = value.ToArray();
      return SetBetValidations(arr);
    }
  }
}
