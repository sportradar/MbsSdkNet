using Sportradar.Mbs.Sdk.Entities.Common;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a request to inform about a financial limit.
/// </summary>
public class FinancialLimitInformRequest : ContentRequestBase
{
    /// <summary>
    /// JSON property that defines the type of request.
    /// </summary>
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "financial-limit-inform";

    /// <summary>
    /// The amount associated with the financial limit.
    /// </summary>
    [JsonPropertyName("amount")]
    public Amount? Amount { get; set; }

    /// <summary>
    /// The end customer affected by the financial limit.
    /// </summary>
    [JsonPropertyName("endCustomer")]
    public EndCustomer? EndCustomer { get; set; }

    /// <summary>
    /// The type of financial limit.
    /// </summary>
    [JsonPropertyName("limitType")]
    public FinancialLimitType? LimitType { get; set; }

    /// <summary>
    /// The frequency of the financial limit.
    /// </summary>
    [JsonPropertyName("frequency")]
    public LimitFrequency? Frequency { get; set; }
}