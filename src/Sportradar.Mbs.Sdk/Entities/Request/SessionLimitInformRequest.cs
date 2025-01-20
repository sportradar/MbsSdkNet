using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Entities.Common;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a request to inform about a session limit change.
/// </summary>
public class SessionLimitInformRequest : ContentRequestBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "session-limit-inform";

    /// <summary>
    /// Gets or sets the end customer information.
    /// </summary>
    [JsonPropertyName("endCustomer")]
    public EndCustomer? EndCustomer { get; set; }

    /// <summary>
    /// Gets or sets the UTC millis timestamp when the limit change was made.
    /// </summary>
    [JsonPropertyName("timestampUtc")]
    public long TimestampUtc { get; set; }

    /// <summary>
    /// Gets or sets the new session limit duration in minutes.
    /// </summary>
    [JsonPropertyName("duration")]
    public int Duration { get; set; }
}