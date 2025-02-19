using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a request to inform about an account status change.
/// </summary>
public class AccountStatusInformRequest : ContentRequestBase
{
    /// <summary>
    /// JSON property that defines the type of request.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "account-status-inform";

    /// <summary>
    /// Duration of the account status change.
    /// </summary>
    [JsonPropertyName("duration")]
    public StatusDuration? Duration { get; set; }

    /// <summary>
    /// Reason for the account status change.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// Entity that initiated the request.
    /// </summary>
    [JsonPropertyName("initiator")]
    public Initiator? Initiator { get; set; }

    /// <summary>
    /// End customer affected by the status change.
    /// </summary>
    [JsonPropertyName("endCustomer")]
    public EndCustomer? EndCustomer { get; set; }

    /// <summary>
    /// Start time of the status period in UTC (epoch time).
    /// </summary>
    [JsonPropertyName("periodStartUtc")]
    public long PeriodStartUtc { get; set; }

    /// <summary>
    /// Status value associated with the request.
    /// </summary>
    [JsonPropertyName("status")]
    public StatusValue? Status { get; set; }

    /// <summary>
    /// End time of the status period in UTC (epoch time).
    /// </summary>
    [JsonPropertyName("periodEndUtc")]
    public long PeriodEndUtc { get; set; }
}
