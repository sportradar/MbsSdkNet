using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

public class ErrorResponse : ContentResponseBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "error-reply";

  [JsonPropertyName("message")]
  public String? ErrorMessage { get; set; }

  [JsonPropertyName("code")]
  public int ErrorCode { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly ErrorResponse instance = new ErrorResponse();

    internal Builder()
    {
    }

    public ErrorResponse Build()
    {
      return this.instance;
    }

    public Builder SetErrorMessage(String value)
    {
      this.instance.ErrorMessage = value;
      return this;
    }

    public Builder SetErrorCode(int value)
    {
      this.instance.ErrorCode = value;
      return this;
    }
  }
}
