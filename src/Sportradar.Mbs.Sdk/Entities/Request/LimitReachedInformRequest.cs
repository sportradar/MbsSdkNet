using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a request to inform when a limit has been reached.
/// </summary>
public class LimitReachedInformRequest : ContentRequestBase
{
    /// <summary>
    /// JSON property that defines the type of request.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "limit-reached-inform";

    /// <summary>
    /// The end customer affected by the reached limit.
    /// </summary>
    [JsonPropertyName("endCustomer")]
    public EndCustomer? EndCustomer { get; set; }

    /// <summary>
    /// The type of limit that has been reached.
    /// </summary>
    [JsonPropertyName("limitType")]
    public LimitType? LimitType { get; set; }
}