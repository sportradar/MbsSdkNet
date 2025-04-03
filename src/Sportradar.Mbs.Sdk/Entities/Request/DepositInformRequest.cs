using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Entities.Common;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a request to inform about a deposit.
/// </summary>
public class DepositInformRequest : ContentRequestBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "deposit-inform";

    /// <summary>
    /// Gets or sets the wallet ID.
    /// </summary>
    [JsonPropertyName("walletId")]
    public string? WalletId { get; set; }

    /// <summary>
    /// Gets or sets the deposit ID.
    /// </summary>
    [JsonPropertyName("depositId")]
    public string? DepositId { get; set; }

    /// <summary>
    /// Gets or sets the amount of the deposit.
    /// </summary>
    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    /// <summary>
    /// Gets or sets the end customer information.
    /// </summary>
    [JsonPropertyName("endCustomer")]
    public EndCustomer? EndCustomer { get; set; }

    /// <summary>
    /// Gets or sets the UTC millis timestamp when the deposit was executed.
    /// </summary>
    [JsonPropertyName("executedAtUtc")]
    public long ExecutedAtUtc { get; set; }

    /// <summary>
    /// Gets or sets the UTC millis timestamp when the deposit was initiated.
    /// </summary>
    [JsonPropertyName("initiatedAtUtc")]
    public long? InitiatedAtUtc { get; set; }

    /// <summary>
    /// Gets or sets the payment gateway used for the deposit.
    /// </summary>
    [JsonPropertyName("gateway")]
    public PaymentGateway? Gateway { get; set; }

    /// <summary>
    /// Gets or sets the status of the balance move.
    /// </summary>
    [JsonPropertyName("status")]
    public BalanceMoveStatus? Status { get; set; }
}