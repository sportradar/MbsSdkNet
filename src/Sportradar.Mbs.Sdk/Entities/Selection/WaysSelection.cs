using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Selection;

public class WaysSelection : SelectionBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "ways";

  [JsonPropertyName("selections")]
  public SelectionBase[]? Selections { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly WaysSelection instance = new WaysSelection();

    internal Builder()
    {
    }

    public WaysSelection Build()
    {
      return this.instance;
    }

    public Builder SetSelections(params SelectionBase[] value)
    {
      this.instance.Selections = value;
      return this;
    }

    public Builder SetSelections<T>(IList<T> value) where T : SelectionBase
    {
      SelectionBase[] arr = value.ToArray();
      return SetSelections(arr);
    }
  }
}
