using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Internal.Utils;

namespace Sportradar.Mbs.Sdk.Entities.Odds;

/// <summary>
/// Represents fractional odds.
/// </summary>
public class FractionalOdds : OddsBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type  => "fractional";

    /// <summary>
    /// Gets or sets the value of the numerator (top, first part) of the fractional odds.
    /// </summary>
    [JsonConverter(typeof(LongJsonConverter))]
    [JsonPropertyName("numerator")]
    public long? Numerator { get; set; }

    /// <summary>
    /// Gets or sets the value of the denominator (bottom, last part) of the fractional odds.
    /// </summary>
    [JsonConverter(typeof(LongJsonConverter))]
    [JsonPropertyName("denominator")]
    public long? Denominator { get; set; }
}
