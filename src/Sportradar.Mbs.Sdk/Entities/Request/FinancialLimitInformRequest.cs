using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Entities.Account;
using Sportradar.Mbs.Sdk.Entities.Common;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a request to inform about a financial limit change.
/// </summary>
public class FinancialLimitInformRequest : ContentRequestBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "financial-limit-inform";

    /// <summary>
    /// Gets or sets the end customer information.
    /// </summary>
    [JsonPropertyName("endCustomer")]
    public EndCustomer? EndCustomer { get; set; }

    /// <summary>
    /// Gets or sets the type of limit.
    /// </summary>
    [JsonPropertyName("limitType")]
    public FinancialLimitType LimitType { get; set; }

    /// <summary>
    /// Gets or sets the limit frequency.
    /// </summary>
    [JsonPropertyName("frequency")]
    public LimitFrequency Frequency { get; set; }

    /// <summary>
    /// Gets or sets the amount of the limit.
    /// </summary>
    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }
}