using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Entities.Common;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a request to inform about a withdrawal.
/// </summary>
public class WithdrawalInformRequest : ContentRequestBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "withdrawal-inform";

    /// <summary>
    /// Gets or sets the wallet ID.
    /// </summary>
    [JsonPropertyName("walletId")]
    public string? WalletId { get; set; }

    /// <summary>
    /// Gets or sets the withdrawal ID.
    /// </summary>
    [JsonPropertyName("withdrawalId")]
    public string? WithdrawalId { get; set; }

    /// <summary>
    /// Gets or sets the withdrawal amount.
    /// </summary>
    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    /// <summary>
    /// Gets or sets the end customer information.
    /// </summary>
    [JsonPropertyName("endCustomer")]
    public EndCustomer? EndCustomer { get; set; }

    /// <summary>
    /// Gets or sets the UTC millis timestamp when the withdrawal was executed.
    /// </summary>
    [JsonPropertyName("executedAtUtc")]
    public long ExecutedAtUtc { get; set; }

    /// <summary>
    /// Gets or sets the UTC millis timestamp when the withdrawal was initiated.
    /// </summary>
    [JsonPropertyName("initiatedAtUtc")]
    public long? InitiatedAtUtc { get; set; }

    /// <summary>
    /// Gets or sets the payment gateway used for the withdrawal.
    /// </summary>
    [JsonPropertyName("gateway")]
    public PaymentGateway? Gateway { get; set; }

    /// <summary>
    /// Gets or sets the status of the balance move.
    /// </summary>
    [JsonPropertyName("status")]
    public BalanceMoveStatus? Status { get; set; }
}