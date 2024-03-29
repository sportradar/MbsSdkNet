using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Ref;

/// <summary>
/// Represents the base class for ticket references.
/// </summary>
[JsonConverter(typeof(TicketRefBaseJsonConverter))]
public abstract class TicketRefBase
{
}

public class TicketRefBaseJsonConverter : JsonConverter<TicketRefBase>
{
    public override TicketRefBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;
        var type = root.GetProperty("type").GetString();

        TicketRefBase? result = type switch
        {
            "alt-stake" => JsonSerializer.Deserialize<AltStakeTicketRef>(root.GetRawText()),
            "reoffer" => JsonSerializer.Deserialize<ReofferTicketRef>(root.GetRawText()),
            _ => throw new JsonException("Unknown type of TicketRefBase: " + type)
        };
        return result ?? throw new NullReferenceException("Null TicketRefBase: " + type);
    }

    public override void Write(Utf8JsonWriter writer, TicketRefBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}