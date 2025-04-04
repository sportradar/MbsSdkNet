using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Channel;

public class SmsChannel : ChannelBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "sms";

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
    private readonly SmsChannel instance = new SmsChannel();

    internal Builder()
    {
    }

    public SmsChannel Build()
    {
      return this.instance;
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
