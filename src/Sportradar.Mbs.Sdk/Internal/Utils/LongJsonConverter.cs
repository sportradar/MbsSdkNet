using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Internal.Utils;

internal class LongJsonConverter : JsonConverter<long>
{
    public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonVal = reader.GetString();
        if (long.TryParse(jsonVal, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result)) return result;

        throw new JsonException("Unknown long: " + jsonVal);
    }

    public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
    {
        var jsonVal = value.ToString(CultureInfo.InvariantCulture);
        writer.WriteStringValue(jsonVal);
    }
}