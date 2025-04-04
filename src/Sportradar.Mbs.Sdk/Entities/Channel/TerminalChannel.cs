using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Channel;

public class TerminalChannel : ChannelBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "terminal";

  [JsonPropertyName("terminalId")]
  public String? TerminalId { get; set; }

  [JsonPropertyName("shopId")]
  public String? ShopId { get; set; }

  [JsonPropertyName("lang")]
  public String? Lang { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly TerminalChannel instance = new TerminalChannel();

    internal Builder()
    {
    }

    public TerminalChannel Build()
    {
      return this.instance;
    }

    public Builder SetTerminalId(String value)
    {
      this.instance.TerminalId = value;
      return this;
    }

    public Builder SetShopId(String value)
    {
      this.instance.ShopId = value;
      return this;
    }

    public Builder SetLang(String value)
    {
      this.instance.Lang = value;
      return this;
    }
  }
}
