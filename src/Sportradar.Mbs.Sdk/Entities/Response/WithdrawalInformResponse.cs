using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

/// <summary>
/// Represents a response for withdrawal inform.
/// </summary>
public class WithdrawalInformResponse : ContentResponseBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "withdrawal-inform-reply";

    /// <summary>
    /// Gets or sets the code of the withdrawal inform response.
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the message of the withdrawal inform response.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the signature.
    /// </summary>
    [JsonPropertyName("signature")]
    public string? Signature { get; set; }
}