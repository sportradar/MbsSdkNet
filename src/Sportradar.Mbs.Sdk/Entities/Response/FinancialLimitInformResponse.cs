using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Response;

/// <summary>
/// Represents a response to a financial limit inform request.
/// </summary>
public class FinancialLimitInformResponse : ContentResponseBase
{
    /// <summary>
    /// JSON property that defines the type of response.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "financial-limit-inform-reply";

    /// <summary>
    /// The response code indicating the status of the request.
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// The digital signature for verification.
    /// </summary>
    [JsonPropertyName("signature")]
    public string? Signature { get; set; }

    /// <summary>
    /// An optional message providing additional details about the response.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}
