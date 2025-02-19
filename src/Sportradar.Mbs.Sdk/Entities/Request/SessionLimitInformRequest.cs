using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a request to inform about a session limit.
/// </summary>
public class SessionLimitInformRequest : ContentRequestBase
{
    /// <summary>
    /// JSON property that defines the type of request.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "session-limit-inform";

    /// <summary>
    /// The duration of the session limit in minutes.
    /// </summary>
    [JsonPropertyName("duration")]
    public int Duration { get; set; }

    /// <summary>
    /// The end customer affected by the session limit.
    /// </summary>
    [JsonPropertyName("endCustomer")]
    public EndCustomer? EndCustomer { get; set; }
}
