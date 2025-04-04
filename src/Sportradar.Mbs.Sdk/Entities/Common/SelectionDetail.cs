using Sportradar.Mbs.Sdk.Entities.Odds;
using Sportradar.Mbs.Sdk.Entities.Selection;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

public class SelectionDetail
{

  [JsonPropertyName("code")]
  public int Code { get; set; }

  [JsonPropertyName("selection")]
  public SelectionBase? Selection { get; set; }

  [JsonPropertyName("message")]
  public String? Message { get; set; }

  [JsonPropertyName("autoAcceptedOdds")]
  public OddsBase? AutoAcceptedOdds { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly SelectionDetail instance = new SelectionDetail();

    internal Builder()
    {
    }

    public SelectionDetail Build()
    {
      return this.instance;
    }

    public Builder SetCode(int value)
    {
      this.instance.Code = value;
      return this;
    }

    public Builder SetSelection(SelectionBase value)
    {
      this.instance.Selection = value;
      return this;
    }

    public Builder SetMessage(String value)
    {
      this.instance.Message = value;
      return this;
    }

    public Builder SetAutoAcceptedOdds(OddsBase value)
    {
      this.instance.AutoAcceptedOdds = value;
      return this;
    }
  }
}
