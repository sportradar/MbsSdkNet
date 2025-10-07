using Sportradar.Mbs.Sdk.Entities.Payoutmodifiersettlement;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class PayoutModifierSettlementRequest : ContentRequestBase
{
  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "payout-modifier-settlement";

  [JsonPropertyName("reference")]
  public String? Reference { get; set; }

  [JsonPropertyName("settlementId")]
  public String? SettlementId { get; set; }

  [JsonPropertyName("settlement")]
  public PayoutModifierSettlementBase? Settlement { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly PayoutModifierSettlementRequest instance = new PayoutModifierSettlementRequest();

    internal Builder()
    {
    }

    public PayoutModifierSettlementRequest Build()
    {
      return this.instance;
    }

    public Builder SetReference(String value)
    {
      this.instance.Reference = value;
      return this;
    }

    public Builder SetSettlementId(String value)
    {
      this.instance.SettlementId = value;
      return this;
    }

    public Builder SetSettlement(PayoutModifierSettlementBase value)
    {
      this.instance.Settlement = value;
      return this;
    }
  }
}