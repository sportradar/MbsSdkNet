using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Odds;

[JsonConverter(typeof(OddsBaseJsonConverter))]
public abstract class OddsBase
{

  public static IndonesianOdds.Builder NewIndonesianOddsBuilder()
  {
    return IndonesianOdds.NewBuilder();
  }

  public static HongKongOdds.Builder NewHongKongOddsBuilder()
  {
    return HongKongOdds.NewBuilder();
  }

  public static FractionalOdds.Builder NewFractionalOddsBuilder()
  {
    return FractionalOdds.NewBuilder();
  }

  public static DecimalOdds.Builder NewDecimalOddsBuilder()
  {
    return DecimalOdds.NewBuilder();
  }

  public static MoneylineOdds.Builder NewMoneylineOddsBuilder()
  {
    return MoneylineOdds.NewBuilder();
  }

  public static MalayOdds.Builder NewMalayOddsBuilder()
  {
    return MalayOdds.NewBuilder();
  }

}

public class OddsBaseJsonConverter : JsonConverter<OddsBase>
{

  public override OddsBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    OddsBase? result = type switch
    {
      "decimal" => JsonSerializer.Deserialize<DecimalOdds>(root.GetRawText()),
      "fractional" => JsonSerializer.Deserialize<FractionalOdds>(root.GetRawText()),
      "hong-kong" => JsonSerializer.Deserialize<HongKongOdds>(root.GetRawText()),
      "indonesian" => JsonSerializer.Deserialize<IndonesianOdds>(root.GetRawText()),
      "malay" => JsonSerializer.Deserialize<MalayOdds>(root.GetRawText()),
      "moneyline" => JsonSerializer.Deserialize<MoneylineOdds>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of OddsBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null OddsBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, OddsBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
