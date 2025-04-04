using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

public class CashoutInformResponse : ContentResponseBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "cashout-inform-reply";

  [JsonPropertyName("code")]
  public int Code { get; set; }

  [JsonPropertyName("signature")]
  public String? Signature { get; set; }

  [JsonPropertyName("cashoutId")]
  public String? CashoutId { get; set; }

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
    private readonly CashoutInformResponse instance = new CashoutInformResponse();

    internal Builder()
    {
    }

    public CashoutInformResponse Build()
    {
      return this.instance;
    }

    public Builder SetCode(int value)
    {
      this.instance.Code = value;
      return this;
    }

    public Builder SetSignature(String value)
    {
      this.instance.Signature = value;
      return this;
    }

    public Builder SetCashoutId(String value)
    {
      this.instance.CashoutId = value;
      return this;
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
