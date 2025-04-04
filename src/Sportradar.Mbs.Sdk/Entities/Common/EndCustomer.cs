using Sportradar.Mbs.Sdk.Internal.Utils;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class EndCustomer
{

  [JsonConverter(typeof(DecimalJsonConverter))]
  [JsonPropertyName("confidence")]
  public decimal? Confidence { get; set; }

  [JsonPropertyName("id")]
  public String? Id { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly EndCustomer instance = new EndCustomer();

    internal Builder()
    {
    }

    public EndCustomer Build()
    {
      return this.instance;
    }

    public Builder SetConfidence(decimal value)
    {
      this.instance.Confidence = value;
      return this;
    }

    public Builder SetId(String value)
    {
      this.instance.Id = value;
      return this;
    }
  }
}
