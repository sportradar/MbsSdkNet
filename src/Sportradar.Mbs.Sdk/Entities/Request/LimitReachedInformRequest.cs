using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Entities.Account;
using Sportradar.Mbs.Sdk.Entities.Common;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a request to inform about a limit reached event.
/// </summary>
public class LimitReachedInformRequest : ContentRequestBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "limit-reached-inform";

    /// <summary>
    /// Gets or sets the end customer information.
    /// </summary>
    [JsonPropertyName("endCustomer")]
    public EndCustomer? EndCustomer { get; set; }

    /// <summary>
    /// Gets or sets the UTC millis timestamp when the limit was reached.
    /// </summary>
    [JsonPropertyName("timestampUtc")]
    public long TimestampUtc { get; set; }

    /// <summary>
    /// Gets or sets the type of limit that was reached.
    /// </summary>
    [JsonPropertyName("limitType")]
    public LimitType LimitType { get; set; }
}