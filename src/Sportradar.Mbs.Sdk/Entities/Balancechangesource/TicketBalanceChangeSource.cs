using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Balancechangesource;

public class TicketBalanceChangeSource : BalanceChangeSourceBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ticket";

  [JsonPropertyName("action")]
  public TicketBalanceChangeAction? Action { get; set; }

  [JsonPropertyName("id")]
  public String? Id { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly TicketBalanceChangeSource instance = new TicketBalanceChangeSource();

    internal Builder()
    {
    }

    public TicketBalanceChangeSource Build()
    {
      return this.instance;
    }

    public Builder SetAction(TicketBalanceChangeAction value)
    {
      this.instance.Action = value;
      return this;
    }

    public Builder SetId(String value)
    {
      this.instance.Id = value;
      return this;
    }
  }
}
