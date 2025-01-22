using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

/// <summary>
/// Represents a response for a balance change inform request.
/// </summary>
public class BalanceChangeInformResponse : ContentResponseBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "balance-change-inform-reply";

    /// <summary>
    /// Gets or sets the code of the balance change inform reply.
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the message of the balance change inform reply.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the signature.
    /// </summary>
    [JsonPropertyName("signature")]
    public string? Signature { get; set; }

}