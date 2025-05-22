using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Resulting;

public class UnsettledSelectionResult : SelectionResultBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "unsettled";

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly UnsettledSelectionResult instance = new UnsettledSelectionResult();

    internal Builder()
    {
    }

    public UnsettledSelectionResult Build()
    {
      return this.instance;
    }
  }
}
