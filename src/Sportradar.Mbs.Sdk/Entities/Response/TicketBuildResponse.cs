using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

public class TicketBuildResponse : ContentResponseBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket-build-reply";

  [JsonPropertyName("code")]
  public int Code { get; set; }

  [JsonPropertyName("channelSuggestions")]
  public ChannelSuggestions? ChannelSuggestions { get; set; }

  [JsonPropertyName("exchangeRate")]
  public ExchangeRate[]? ExchangeRate { get; set; }

  [JsonPropertyName("signature")]
  public String? Signature { get; set; }

  [JsonPropertyName("betDetails")]
  public TicketBuildReplyBetDetail[]? BetDetails { get; set; }

  [JsonPropertyName("endCustomerSuggestions")]
  public EndCustomerSuggestions? EndCustomerSuggestions { get; set; }

  [JsonPropertyName("message")]
  public String? Message { get; set; }

  [JsonPropertyName("ltd")]
  public LtdSuggestions? Ltd { get; set; }

  [JsonPropertyName("ticketId")]
  public String? TicketId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly TicketBuildResponse instance = new TicketBuildResponse();

    internal Builder()
    {
    }

    public TicketBuildResponse Build()
    {
      return this.instance;
    }

    public Builder SetCode(int value)
    {
      this.instance.Code = value;
      return this;
    }

    public Builder SetChannelSuggestions(ChannelSuggestions value)
    {
      this.instance.ChannelSuggestions = value;
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

    public Builder SetBetDetails(params TicketBuildReplyBetDetail[] value)
    {
      this.instance.BetDetails = value;
      return this;
    }

    public Builder SetBetDetails<T>(IList<T> value) where T : TicketBuildReplyBetDetail
    {
      TicketBuildReplyBetDetail[] arr = value.ToArray();
      return SetBetDetails(arr);
    }

    public Builder SetEndCustomerSuggestions(EndCustomerSuggestions value)
    {
      this.instance.EndCustomerSuggestions = value;
      return this;
    }

    public Builder SetMessage(String value)
    {
      this.instance.Message = value;
      return this;
    }

    public Builder SetLtd(LtdSuggestions value)
    {
      this.instance.Ltd = value;
      return this;
    }

    public Builder SetTicketId(String value)
    {
      this.instance.TicketId = value;
      return this;
    }
  }
}
