using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

public class TicketResponse : ContentResponseBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket-reply";

  [JsonPropertyName("code")]
  public int Code { get; set; }

  [JsonPropertyName("exchangeRate")]
  public ExchangeRate[]? ExchangeRate { get; set; }

  [JsonPropertyName("signature")]
  public String? Signature { get; set; }

  [JsonPropertyName("betDetails")]
  public BetDetail[]? BetDetails { get; set; }

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
    private readonly TicketResponse instance = new TicketResponse();

    internal Builder()
    {
    }

    public TicketResponse Build()
    {
      return this.instance;
    }

    public Builder SetCode(int value)
    {
      this.instance.Code = value;
      return this;
    }

    public Builder SetExchangeRate(params ExchangeRate[] value)
    {
      this.instance.ExchangeRate = value;
      return this;
    }

    public Builder SetExchangeRate<T>(IList<T> value) where T : ExchangeRate
    {
      ExchangeRate[] arr = value.ToArray();
      return SetExchangeRate(arr);
    }

    public Builder SetSignature(String value)
    {
      this.instance.Signature = value;
      return this;
    }

    public Builder SetBetDetails(params BetDetail[] value)
    {
      this.instance.BetDetails = value;
      return this;
    }

    public Builder SetBetDetails<T>(IList<T> value) where T : BetDetail
    {
      BetDetail[] arr = value.ToArray();
      return SetBetDetails(arr);
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
