using Sportradar.Mbs.Sdk.Entities.Location;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Channel;

public class RetailChannel : ChannelBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "retail";

  [JsonPropertyName("location")]
  public LocationBase? Location { get; set; }

  [JsonPropertyName("shopId")]
  public String? ShopId { get; set; }

  [JsonPropertyName("lang")]
  public String? Lang { get; set; }

  [JsonPropertyName("deviceId")]
  public String? DeviceId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly RetailChannel instance = new RetailChannel();

    internal Builder()
    {
    }

    public RetailChannel Build()
    {
      return this.instance;
    }

    public Builder SetLocation(LocationBase value)
    {
      this.instance.Location = value;
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

    public Builder SetDeviceId(String value)
    {
      this.instance.DeviceId = value;
      return this;
    }
  }
}
