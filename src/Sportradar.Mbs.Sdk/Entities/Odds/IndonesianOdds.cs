using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Internal.Utils;

namespace Sportradar.Mbs.Sdk.Entities.Odds;

/// <summary>
/// Represents indonesian odds.
/// </summary>
public class IndonesianOdds : OddsBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type  => "indonesian";

    /// <summary>
    /// Gets or sets the indonesian value of the odds: eg "-3.4".
    /// </summary>
    [JsonConverter(typeof(DecimalJsonConverter))]
    [JsonPropertyName("value")]
    public decimal? Value { get; set; }
}
