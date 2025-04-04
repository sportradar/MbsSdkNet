using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Accountlimit;

public class SessionAccountLimit : AccountLimitBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "session";

  [JsonPropertyName("duration")]
  public int Duration { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly SessionAccountLimit instance = new SessionAccountLimit();

    internal Builder()
    {
    }

    public SessionAccountLimit Build()
    {
      return this.instance;
    }

    public Builder SetDuration(int value)
    {
      this.instance.Duration = value;
      return this;
    }
  }
}
