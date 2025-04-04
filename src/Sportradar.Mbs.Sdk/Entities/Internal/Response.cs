using Sportradar.Mbs.Sdk.Entities.Response;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Internal;

public class Response
{

  [JsonPropertyName("correlationId")]
  public String? CorrelationId { get; set; }

  [JsonPropertyName("timestampUtc")]
  public long TimestampUtc { get; set; }

  [JsonPropertyName("operation")]
  public String? Operation { get; set; }

  [JsonPropertyName("version")]
  public String? Version { get; set; }

  [JsonPropertyName("content")]
  public ContentResponseBase? Content { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly Response instance = new Response();

    internal Builder()
    {
    }

    public Response Build()
    {
      return this.instance;
    }

    public Builder SetCorrelationId(String value)
    {
      this.instance.CorrelationId = value;
      return this;
    }

    public Builder SetTimestampUtc(long value)
    {
      this.instance.TimestampUtc = value;
      return this;
    }

    public Builder SetOperation(String value)
    {
      this.instance.Operation = value;
      return this;
    }

    public Builder SetVersion(String value)
    {
      this.instance.Version = value;
      return this;
    }

    public Builder SetContent(ContentResponseBase value)
    {
      this.instance.Content = value;
      return this;
    }
  }
}
