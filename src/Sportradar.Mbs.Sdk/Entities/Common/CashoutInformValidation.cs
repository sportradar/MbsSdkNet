using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

/// <summary>
/// Represents validation object.
/// </summary>
public class CashoutInformValidation
{
    /// <summary>
    /// Gets or sets the code.
    /// </summary>
    [JsonPropertyName("code")]
    public int? Code { get; set; }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    
    /// <summary>
    /// Gets or sets the rejected flag.
    /// </summary>
    [JsonPropertyName("rejected")]
    public bool? Rejected { get; set; }
}