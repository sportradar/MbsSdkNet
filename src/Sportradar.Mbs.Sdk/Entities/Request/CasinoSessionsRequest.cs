using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

public class CasinoSessionsRequest : ContentRequestBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "casino-sessions-inform";

  [JsonPropertyName("sessions")]
  public CasinoSession[]? Sessions { get; set; }

  [JsonPropertyName("reportId")]
  public String? ReportId { get; set; }

  [JsonPropertyName("context")]
  public CasinoContext? Context { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly CasinoSessionsRequest instance = new CasinoSessionsRequest();

    internal Builder()
    {
    }

    public CasinoSessionsRequest Build()
    {
      return this.instance;
    }

    public Builder SetSessions(params CasinoSession[] value)
    {
      this.instance.Sessions = value;
      return this;
    }

    public Builder SetSessions<T>(IList<T> value) where T : CasinoSession
    {
      CasinoSession[] arr = value.ToArray();
      return SetSessions(arr);
    }

    public Builder SetReportId(String value)
    {
      this.instance.ReportId = value;
      return this;
    }

    public Builder SetContext(CasinoContext value)
    {
      this.instance.Context = value;
      return this;
    }
  }
}
