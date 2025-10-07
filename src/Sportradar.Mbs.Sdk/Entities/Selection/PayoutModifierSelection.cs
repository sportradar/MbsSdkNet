using Sportradar.Mbs.Sdk.Entities.Selection;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Selection;

public class PayoutModifierSelection : SelectionBase
{
  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "payout-modifier";

  [JsonPropertyName("reference")]
  public String? Reference { get; set; }

  [JsonPropertyName("selection")]
  public SelectionBase? Selection { get; set; }

  [JsonPropertyName("description")]
  public String? Description { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly PayoutModifierSelection instance = new PayoutModifierSelection();

    internal Builder()
    {
    }

    public PayoutModifierSelection Build()
    {
      return this.instance;
    }

    public Builder SetReference(String value)
    {
      this.instance.Reference = value;
      return this;
    }

    public Builder SetSelection(SelectionBase value)
    {
      this.instance.Selection = value;
      return this;
    }

    public Builder SetDescription(String value)
    {
      this.instance.Description = value;
      return this;
    }
  }
}