using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Channel;

public class CallCentreChannel : ChannelBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "call-centre";

  [JsonPropertyName("lang")]
  public String? Lang { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CallCentreChannel instance = new CallCentreChannel();

    internal Builder()
    {
    }

    public CallCentreChannel Build()
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
