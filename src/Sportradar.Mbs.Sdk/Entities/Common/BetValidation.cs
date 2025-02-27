using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

/// <summary>
/// Represents the validation result of a bet.
/// </summary>
public class BetValidation
{
    /// <summary>
    /// Gets or sets the validation code.
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the bet ID.
    /// </summary>
    [JsonPropertyName("betId")]
    public string? BetId { get; set; }

    /// <summary>
    /// Gets or sets the validation message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    
    /// <summary>
    /// Gets or sets the rejected flag.
    /// </summary>
    [JsonPropertyName("rejected")]
    public bool? Rejected { get; set; }
}