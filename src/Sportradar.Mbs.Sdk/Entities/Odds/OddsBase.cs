using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Odds;

/// <summary>
/// Represents the base class for odds entities.
/// </summary>
[JsonConverter(typeof(OddsBaseJsonConverter))]
public abstract class OddsBase
{
}

public class OddsBaseJsonConverter : JsonConverter<OddsBase>
{
    public override OddsBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        var type = root.GetProperty("type").GetString();

        OddsBase? result = type switch
        {
            "indonesian" => JsonSerializer.Deserialize<IndonesianOdds>(root.GetRawText()),
            "hong-kong" => JsonSerializer.Deserialize<HongKongOdds>(root.GetRawText()),
            "fractional" => JsonSerializer.Deserialize<FractionalOdds>(root.GetRawText()),
            "decimal" => JsonSerializer.Deserialize<DecimalOdds>(root.GetRawText()),
            "moneyline" => JsonSerializer.Deserialize<MoneylineOdds>(root.GetRawText()),
            "malay" => JsonSerializer.Deserialize<MalayOdds>(root.GetRawText()),
            _ => throw new JsonException("Unknown type of OddsBase: " + type)
        };
        return result ?? throw new NullReferenceException("Null OddsBase: " + type);
    }

    public override void Write(Utf8JsonWriter writer, OddsBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}