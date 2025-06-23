using System.Text.Json.Serialization;

namespace Sportradar.Mbs.Sdk.Entities.Location;

public class GeoLocation : LocationBase
{

  [JsonInclude]
  [JsonPropertyName("type")]
  private string Type => "geo";

  [JsonPropertyName("latitude")]
  public double Latitude { get; set; }

  [JsonPropertyName("longitude")]
  public double Longitude { get; set; }

  public static Builder NewBuilder()
  {
    return new Builder();
  }

  public class Builder
  {
    private readonly GeoLocation instance = new GeoLocation();

    internal Builder()
    {
    }

    public GeoLocation Build()
    {
      return this.instance;
    }

    public Builder SetLatitude(double value)
    {
      this.instance.Latitude = value;
      return this;
    }

    public Builder SetLongitude(double value)
    {
      this.instance.Longitude = value;
      return this;
    }
  }
}
