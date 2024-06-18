using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Internal.Utils;

internal class DecimalJsonConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonVal = reader.GetString();
        if (decimal.TryParse(jsonVal, NumberStyles.Number, CultureInfo.InvariantCulture, out var result)) return result;

        throw new JsonException("Unknown decimal: " + jsonVal);
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        var jsonVal = value.ToString("0.0#######", CultureInfo.InvariantCulture);
        writer.WriteStringValue(jsonVal);
    }
}