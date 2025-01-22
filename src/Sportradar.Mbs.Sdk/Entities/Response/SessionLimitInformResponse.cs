using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

/// <summary>
/// Represents a response for session limit inform.
/// </summary>
public class SessionLimitInformResponse : ContentResponseBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "session-limit-inform-reply";

    /// <summary>
    /// Gets or sets the code of the session limit inform response.
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the message of the session limit inform response.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the signature.
    /// </summary>
    [JsonPropertyName("signature")]
    public string? Signature { get; set; }
}