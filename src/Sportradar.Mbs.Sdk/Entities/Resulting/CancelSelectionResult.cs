using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Resulting;

public class CancelSelectionResult : SelectionResultBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "cancel";

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CancelSelectionResult instance = new CancelSelectionResult();

    internal Builder()
    {
    }

    public CancelSelectionResult Build()
    {
      return this.instance;
    }
  }
}
