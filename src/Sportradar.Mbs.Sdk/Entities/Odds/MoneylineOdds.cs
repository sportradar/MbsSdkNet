using System.Text.Json.Serialization;
using Sportradar.Mbs.Sdk.Internal.Utils;

namespace Sportradar.Mbs.Sdk.Entities.Odds;

/// <summary>
/// Represents moneyline odds.
/// </summary>
public class MoneylineOdds : OddsBase
{
    [JsonInclude]
    [JsonPropertyName("type")]
    private string Type  => "moneyline";

    /// <summary>
    /// Gets or sets the moneyline value of the odds: eg "-340".
    /// </summary>
    [JsonConverter(typeof(LongJsonConverter))]
    [JsonPropertyName("value")]
    public long? Value { get; set; }
}
