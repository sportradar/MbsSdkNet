using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Channel;

[JsonConverter(typeof(ChannelBaseJsonConverter))]
public abstract class ChannelBase
{

  public static TvAppChannel.Builder NewTvAppChannelBuilder()
  {
    return TvAppChannel.NewBuilder();
  }

  public static AgentChannel.Builder NewAgentChannelBuilder()
  {
    return AgentChannel.NewBuilder();
  }

  public static MobileAppChannel.Builder NewMobileAppChannelBuilder()
  {
    return MobileAppChannel.NewBuilder();
  }

  public static PhoneChannel.Builder NewPhoneChannelBuilder()
  {
    return PhoneChannel.NewBuilder();
  }

  public static CallCentreChannel.Builder NewCallCentreChannelBuilder()
  {
    return CallCentreChannel.NewBuilder();
  }

  public static SmsChannel.Builder NewSmsChannelBuilder()
  {
    return SmsChannel.NewBuilder();
  }

  public static MobileChannel.Builder NewMobileChannelBuilder()
  {
    return MobileChannel.NewBuilder();
  }

  public static TerminalChannel.Builder NewTerminalChannelBuilder()
  {
    return TerminalChannel.NewBuilder();
  }

  public static InternetChannel.Builder NewInternetChannelBuilder()
  {
    return InternetChannel.NewBuilder();
  }

  public static RetailChannel.Builder NewRetailChannelBuilder()
  {
    return RetailChannel.NewBuilder();
  }

}

public class ChannelBaseJsonConverter : JsonConverter<ChannelBase>
{

  public override ChannelBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    var root = doc.RootElement;
    var type = root.GetProperty("type").GetString();

    ChannelBase? result = type switch
    {
      "agent" => JsonSerializer.Deserialize<AgentChannel>(root.GetRawText()),
      "call-centre" => JsonSerializer.Deserialize<CallCentreChannel>(root.GetRawText()),
      "internet" => JsonSerializer.Deserialize<InternetChannel>(root.GetRawText()),
      "mobile" => JsonSerializer.Deserialize<MobileChannel>(root.GetRawText()),
      "mobile-app" => JsonSerializer.Deserialize<MobileAppChannel>(root.GetRawText()),
      "phone" => JsonSerializer.Deserialize<PhoneChannel>(root.GetRawText()),
      "retail" => JsonSerializer.Deserialize<RetailChannel>(root.GetRawText()),
      "sms" => JsonSerializer.Deserialize<SmsChannel>(root.GetRawText()),
      "terminal" => JsonSerializer.Deserialize<TerminalChannel>(root.GetRawText()),
      "tv-app" => JsonSerializer.Deserialize<TvAppChannel>(root.GetRawText()),
      _ => throw new JsonException("Unknown type of ChannelBase: " + type)
    };
    return result ?? throw new NullReferenceException("Null ChannelBase: " + type);
  }

  public override void Write(Utf8JsonWriter writer, ChannelBase value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }

}
