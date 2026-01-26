using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class CampaignOptinRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "campaign-optin";

  [JsonPropertyName("walletId")]
  public String? WalletId { get; set; }

  [JsonPropertyName("campaignId")]
  public String? CampaignId { get; set; }

  [JsonPropertyName("endCustomer")]
  public EndCustomer? EndCustomer { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CampaignOptinRequest instance = new CampaignOptinRequest();

    internal Builder()
    {
    }

    public CampaignOptinRequest Build()
    {
      return this.instance;
    }

    public Builder SetWalletId(String value)
    {
      this.instance.WalletId = value;
      return this;
    }

    public Builder SetCampaignId(String value)
    {
      this.instance.CampaignId = value;
      return this;
    }

    public Builder SetEndCustomer(EndCustomer value)
    {
      this.instance.EndCustomer = value;
      return this;
    }
  }
}
