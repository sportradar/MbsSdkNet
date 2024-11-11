using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Entities.Common;

namespace Sportradar.Mbs.Sdk.Entities.Request;

/// <summary>
/// Represents a request to acknowledge a cashout inform.
/// </summary>
public class CashoutInformRequest : ContentRequestBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type => "cashout-inform";

    /// <summary>
    /// Gets or sets the cashout object.
    /// </summary>
    [JsonPropertyName("cashout")]
    public CashoutRequest? Cashout { get; set; }

    /// <summary>
    /// Gets or sets the cashout inform validation object.
    /// </summary>
    [JsonPropertyName("validation")]
    public CashoutInformValidation? Validation{ get; set; }

}