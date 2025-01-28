using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Entities.Account;
using Sportradar.Mbs.Sdk.Entities.Common;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a request to inform about an account status update.
/// </summary>
public class AccountStatusInformRequest : ContentRequestBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "account-status-inform";

    /// <summary>
    /// Gets or sets the end customer information.
    /// </summary>
    [JsonPropertyName("endCustomer")]
    public EndCustomer? EndCustomer { get; set; }

    /// <summary>
    /// Gets or sets the new account status.
    /// </summary>
    [JsonPropertyName("status")]
    public StatusValue Status { get; set; }

    /// <summary>
    /// Gets or sets the status initiator.
    /// </summary>
    [JsonPropertyName("initiator")]
    public Initiator Initiator { get; set; }

    /// <summary>
    /// Gets or sets the reason for change.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// Gets or sets the UTC millis timestamp of the status period start.
    /// </summary>
    [JsonPropertyName("periodStartUtc")]
    public long PeriodStartUtc { get; set; }

    /// <summary>
    /// Gets or sets the UTC millis timestamp of the status period end.
    /// </summary>
    [JsonPropertyName("periodEndUtc")]
    public long PeriodEndUtc { get; set; }
}