using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Internal.Utils;

namespace Sportradar.Mbs.Sdk.Entities.Odds;

/// <summary>
/// Represents hong kong odds.
/// </summary>
public class HongKongOdds : OddsBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type  => "hong-kong";

    /// <summary>
    /// Gets or sets the hong kong value of the odds: eg "0.75".
    /// </summary>
    [JsonConverter(typeof(DecimalJsonConverter))]
    [JsonPropertyName("value")]
    public decimal? Value { get; set; }
}
