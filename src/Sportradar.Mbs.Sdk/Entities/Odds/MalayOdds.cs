using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Internal.Utils;

namespace Sportradar.Mbs.Sdk.Entities.Odds;

/// <summary>
/// Represents malay odds.
/// </summary>
public class MalayOdds : OddsBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type  => "malay";

    /// <summary>
    /// Gets or sets the malay value of the odds: eg "0.75".
    /// </summary>
    [JsonConverter(typeof(DecimalJsonConverter))]
    [JsonPropertyName("value")]
    public decimal? Value { get; set; }
}
