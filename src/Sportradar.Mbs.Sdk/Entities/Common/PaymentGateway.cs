using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class PaymentGateway
{

  [JsonPropertyName("method")]
  public PaymentMethod? Method { get; set; }

  [JsonPropertyName("provider")]
  public String? Provider { get; set; }

  [JsonPropertyName("executedAtUtc")]
  public long ExecutedAtUtc { get; set; }

  [JsonPropertyName("initiatedAtUtc")]
  public long? InitiatedAtUtc { get; set; }

  [JsonPropertyName("referenceId")]
  public String? ReferenceId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly PaymentGateway instance = new PaymentGateway();

    internal Builder()
    {
    }

    public PaymentGateway Build()
    {
      return this.instance;
    }

    public Builder SetMethod(PaymentMethod value)
    {
      this.instance.Method = value;
      return this;
    }

    public Builder SetProvider(String value)
    {
      this.instance.Provider = value;
      return this;
    }

    public Builder SetExecutedAtUtc(long value)
    {
      this.instance.ExecutedAtUtc = value;
      return this;
    }

    public Builder SetInitiatedAtUtc(long value)
    {
      this.instance.InitiatedAtUtc = value;
      return this;
    }

    public Builder SetReferenceId(String value)
    {
      this.instance.ReferenceId = value;
      return this;
    }
  }
}
