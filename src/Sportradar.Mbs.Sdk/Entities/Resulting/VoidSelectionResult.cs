using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Resulting;

public class VoidSelectionResult : SelectionResultBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "void";

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly VoidSelectionResult instance = new VoidSelectionResult();

    internal Builder()
    {
    }

    public VoidSelectionResult Build()
    {
      return this.instance;
    }
  }
}
