using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Location;

[JsonConverter(typeof(LocationBaseJsonConverter))]
public abstract class LocationBase
{

  public static GeoLocation.Builder NewGeoLocationBuilder()
  {
    return GeoLocation.NewBuilder();
  }
}

public class LocationBaseJsonConverter : JsonConverter<LocationBase>
{

  public override LocationBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using var doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    LocationBase? result = type switch
    {
      "geo" => JsonSerializer.Deserialize<GeoLocation>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of LocationBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null LocationBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, LocationBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }
}
