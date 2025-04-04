using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Common;

[JsonConverter(typeof(InterventionMethodJsonConverter))]
public enum InterventionMethod {
  OTHER,
  LIMIT_UPDATE,
  CARE_CALL,
  POPUP,
  RG_MESSAGING,
  EMAIL
}

public class InterventionMethodJsonConverter : JsonConverter<InterventionMethod> {

  public override InterventionMethod Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var jsonVal = reader.GetString();
    return jsonVal switch
    {
      "other" => InterventionMethod.OTHER,
      "limits-update" => InterventionMethod.LIMIT_UPDATE,
      "care-call" => InterventionMethod.CARE_CALL,
      "pop-up" => InterventionMethod.POPUP,
      "rg-messaging" => InterventionMethod.RG_MESSAGING,
      "email" => InterventionMethod.EMAIL,
      _ => throw new JsonException("Unknown type of InterventionMethod: " + jsonVal)
    };
  }

  public override void Write(Utf8JsonWriter writer, InterventionMethod value, JsonSerializerOptions options)
  {
    string jsonVal = value switch
    {
      InterventionMethod.OTHER => "other",
      InterventionMethod.LIMIT_UPDATE => "limits-update",
      InterventionMethod.CARE_CALL => "care-call",
      InterventionMethod.POPUP => "pop-up",
      InterventionMethod.RG_MESSAGING => "rg-messaging",
      InterventionMethod.EMAIL => "email",
      _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
    writer.WriteStringValue(jsonVal);
  }

}
