using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Channel;

public class AgentChannel : ChannelBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "agent";

  [JsonPropertyName("lang")]
  public String? Lang { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly AgentChannel instance = new AgentChannel();

    internal Builder()
    {
    }

    public AgentChannel Build()
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
