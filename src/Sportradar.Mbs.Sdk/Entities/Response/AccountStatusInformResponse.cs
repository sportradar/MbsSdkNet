using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

/// <summary>
/// Represents a response for account status inform.
/// </summary>
public class AccountStatusInformResponse : ContentResponseBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "account-status-inform-reply";

    /// <summary>
    /// Gets or sets the code of the account status inform response.
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the message of the account status inform response.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}