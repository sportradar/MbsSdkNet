using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Channel;

public class InternetChannel : ChannelBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "internet";

  [JsonPropertyName("ip")]
  public String? Ip { get; set; }

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
    private readonly InternetChannel instance = new InternetChannel();

    internal Builder()
    {
    }

    public InternetChannel Build()
    {
      return this.instance;
    }

    public Builder SetIp(String value)
    {
      this.instance.Ip = value;
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
