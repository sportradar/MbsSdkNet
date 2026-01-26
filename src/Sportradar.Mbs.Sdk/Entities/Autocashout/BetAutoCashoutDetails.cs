using Sportradar.Mbs.Sdk.Entities.Autocashoutthreshold;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Autocashout;

public class BetAutoCashoutDetails : AutoCashoutDetailsBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "bet";

  [JsonPropertyName("betId")]
  public String? BetId { get; set; }

  [JsonPropertyName("threshold")]
  public AutoCashoutThresholdBase[]? Threshold { get; set; }

  [JsonPropertyName("ticketSignature")]
  public String? TicketSignature { get; set; }

  [JsonPropertyName("ticketId")]
  public String? TicketId { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly BetAutoCashoutDetails instance = new BetAutoCashoutDetails();

    internal Builder()
    {
    }

    public BetAutoCashoutDetails Build()
    {
      return this.instance;
    }

    public Builder SetBetId(String value)
    {
      this.instance.BetId = value;
      return this;
    }

    public Builder SetThreshold(params AutoCashoutThresholdBase[] value)
    {
      this.instance.Threshold = value;
      return this;
    }

    public Builder SetThreshold<T>(IList<T> value) where T : AutoCashoutThresholdBase
    {
      AutoCashoutThresholdBase[] arr = value.ToArray();
      return SetThreshold(arr);
    }

    public Builder SetTicketSignature(String value)
    {
      this.instance.TicketSignature = value;
      return this;
    }

    public Builder SetTicketId(String value)
    {
      this.instance.TicketId = value;
      return this;
    }
  }
}
