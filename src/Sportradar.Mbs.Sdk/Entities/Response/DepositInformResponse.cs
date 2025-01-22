using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

/// <summary>
/// Represents a response object for deposit inform.
/// </summary>
public class DepositInformResponse : ContentResponseBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "deposit-inform-reply";

    /// <summary>
    /// Gets or sets the code of the deposit inform response.
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the message of the deposit inform response.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the signature.
    /// </summary>
    [JsonPropertyName("signature")]
    public string? Signature { get; set; }
}