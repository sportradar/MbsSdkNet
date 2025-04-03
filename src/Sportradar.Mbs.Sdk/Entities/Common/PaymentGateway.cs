using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

/// <summary>
/// Represents a payment gateway entity.
/// </summary>
public class PaymentGateway
{
    /// <summary>
    /// Gets or sets the payment method.
    /// </summary>
    [JsonPropertyName("method")]
    public PaymentMethod? Method { get; set; }

    /// <summary>
    /// Gets or sets the payment provider.
    /// </summary>
    [JsonPropertyName("provider")]
    public string? Provider { get; set; }

    /// <summary>
    /// Gets or sets the UTC millis timestamp when the payment was executed.
    /// </summary>
    [JsonPropertyName("executedAtUtc")]
    public long ExecutedAtUtc { get; set; }

    /// <summary>
    /// Gets or sets the UTC millis timestamp when the payment was initiated.
    /// </summary>
    [JsonPropertyName("initiatedAtUtc")]
    public long? InitiatedAtUtc { get; set; }

    /// <summary>
    /// Gets or sets the reference ID of the payment (ID in the source system).
    /// </summary>
    [JsonPropertyName("referenceId")]
    public string? ReferenceId { get; set; }
}