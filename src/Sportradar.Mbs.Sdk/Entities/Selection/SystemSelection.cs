using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Selection;

public class SystemSelection : SelectionBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "system";

  [JsonPropertyName("selections")]
  public SelectionBase[]? Selections { get; set; }

  [JsonPropertyName("size")]
  public int[]? Size { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly SystemSelection instance = new SystemSelection();

    internal Builder()
    {
    }

    public SystemSelection Build()
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

    public Builder SetSize(params int[] value)
    {
      this.instance.Size = value;
      return this;
    }

    public Builder SetSize(IList<int> value)
    {
      int[] arr = value.ToArray();
      return SetSize(arr);
    }
  }
}
