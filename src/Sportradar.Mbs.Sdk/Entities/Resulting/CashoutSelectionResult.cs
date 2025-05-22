using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Resulting;

public class CashoutSelectionResult : SelectionResultBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "cashout";

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CashoutSelectionResult instance = new CashoutSelectionResult();

    internal Builder()
    {
    }

    public CashoutSelectionResult Build()
    {
      return this.instance;
    }
  }
}
