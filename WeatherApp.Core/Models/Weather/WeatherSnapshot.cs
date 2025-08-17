namespace WeatherApp.Core.Models.Weather;

public sealed class WeatherSnapshot
{
    public string City { get; }
    public string Description { get; }
    public string? Country { get; }
    public GeoPoint Location { get; }

    public double Temperature { get; }
    public double FeelsLikeTemperature { get; }
    public double MinTemperature { get; }
    public double MaxTemperature { get; }

    public int PressureHpa { get; }
    public int HumidityPercent { get; }

    public double WindSpeedMs { get; }
    public int WindDeg { get; }
    public double? WindGustMs { get; }

    public int CloudinessPercent { get; }

    public DateTimeOffset ObservedAt { get; } // локальное время города (с применением timezone shift)
    public DateTimeOffset? SunriseLocal { get; }
    public DateTimeOffset? SunsetLocal { get; }

    public WeatherCondition Condition { get; }

    public WeatherSnapshot(
        string city, string description, string? country, GeoPoint location,
        double temperature, double feelsLikeTemperature, double minTemperature, double maxTemperature,
        int pressureHpa, int humidityPercent,
        double windSpeedMs, int windDeg, double? windGustMs,
        int cloudinessPercent,
        DateTimeOffset observedAt, DateTimeOffset? sunriseLocal, DateTimeOffset? sunsetLocal,
        WeatherCondition condition)
    {
        City = city;
        Description = description;
        Country = country;
        Location = location;
        Temperature = temperature;
        FeelsLikeTemperature = feelsLikeTemperature;
        MinTemperature = minTemperature;
        MaxTemperature = maxTemperature;
        PressureHpa = pressureHpa;
        HumidityPercent = humidityPercent;
        WindSpeedMs = windSpeedMs;
        WindDeg = windDeg;
        WindGustMs = windGustMs;
        CloudinessPercent = cloudinessPercent;
        ObservedAt = observedAt;
        SunriseLocal = sunriseLocal;
        SunsetLocal = sunsetLocal;
        Condition = condition;
    }
}

public sealed class GeoPoint(double lat, double lon)
{
    public double Lat { get; } = lat;
    public double Lon { get; } = lon;
}

public enum WeatherCondition
{
    Unknown = 0,
    Clear,
    Clouds,
    Rain,
    Drizzle,
    Thunderstorm,
    Snow,
    Mist,
    Fog,
    Haze,
    Dust,
    Smoke,
    Sand,
    Ash,
    Squall,
    Tornado
}