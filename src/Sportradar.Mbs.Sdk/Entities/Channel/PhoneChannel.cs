using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Channel;

public class PhoneChannel : ChannelBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "phone";

  [JsonPropertyName("lang")]
  public String? Lang { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly PhoneChannel instance = new PhoneChannel();

    internal Builder()
    {
    }

    public PhoneChannel Build()
    {
      return this.instance;
    }

    public Builder SetLang(String value)
    {
      this.instance.Lang = value;
      return this;
    }
  }
}
