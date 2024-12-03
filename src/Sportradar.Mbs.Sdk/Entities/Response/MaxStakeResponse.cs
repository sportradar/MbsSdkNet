using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Entities.Common;

namespace Sportradar.Mbs.Sdk.Entities.Response;

/// <summary>
/// Represents the response received from max stake API.
/// </summary>
public class MaxStakeResponse : ContentResponseBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type  => "max-stake-reply";

    /// <summary>
    /// Gets or sets the code of the max stake response.
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the bets associated with the max stake response.
    /// </summary>
    [JsonPropertyName("bets")]
    public Bet[]? Bets { get; set; }

    /// <summary>
    /// Gets or sets the message of the max stake response.
    /// </summary>
    [JsonPropertyName("message")]
    public String? Message { get; set; }
}