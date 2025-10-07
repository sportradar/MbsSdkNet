using Sportradar.Mbs.Sdk.Entities.Common;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

public class PayoutModifierSettlementResponse : ContentResponseBase
{
  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "payout-modifier-settlement-reply";

  [JsonPropertyName("reference")]
  public String? Reference { get; set; }

  [JsonPropertyName("code")]
  public int Code { get; set; }

  [JsonPropertyName("signature")]
  public String? Signature { get; set; }

  [JsonPropertyName("settlementId")]
  public String? SettlementId { get; set; }

  [JsonPropertyName("message")]
  public String? Message { get; set; }

  [JsonPropertyName("status")]
  public AcceptanceStatus? Status { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly PayoutModifierSettlementResponse instance = new PayoutModifierSettlementResponse();

    internal Builder()
    {
    }

    public PayoutModifierSettlementResponse Build()
    {
      return this.instance;
    }

    public Builder SetReference(String value)
    {
      this.instance.Reference = value;
      return this;
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

    public Builder SetSettlementId(String value)
    {
      this.instance.SettlementId = value;
      return this;
    }

    public Builder SetMessage(String value)
    {
      this.instance.Message = value;
      return this;
    }

    public Builder SetStatus(AcceptanceStatus value)
    {
      this.instance.Status = value;
      return this;
    }
  }
}