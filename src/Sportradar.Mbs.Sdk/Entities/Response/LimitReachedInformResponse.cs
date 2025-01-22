using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

/// <summary>
/// Represents a response for limit reached inform.
/// </summary>
public class LimitReachedInformResponse : ContentResponseBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "limit-reached-inform-reply";

    /// <summary>
    /// Gets or sets the code of the limit reached inform response.
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the message of the limit reached inform response.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the signature.
    /// </summary>
    [JsonPropertyName("signature")]
    public string? Signature { get; set; }
}