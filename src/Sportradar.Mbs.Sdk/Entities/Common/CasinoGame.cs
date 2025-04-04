using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class CasinoGame
{

  [JsonPropertyName("provider")]
  public String? Provider { get; set; }

  [JsonPropertyName("id")]
  public String? Id { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CasinoGame instance = new CasinoGame();

    internal Builder()
    {
    }

    public CasinoGame Build()
    {
      return this.instance;
    }

    public Builder SetProvider(String value)
    {
      this.instance.Provider = value;
      return this;
    }

    public Builder SetId(String value)
    {
      this.instance.Id = value;
      return this;
    }
  }
}
