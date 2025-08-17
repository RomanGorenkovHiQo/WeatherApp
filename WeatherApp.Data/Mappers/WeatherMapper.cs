using WeatherApp.Core.Models.Weather;
using WeatherApp.Data.Models.OpenWeather;

namespace WeatherApp.Data.Mappers;

public static class WeatherMapper
{
    public static WeatherSnapshot ToDomain(this WeatherResponseDto dto)
    {
        var tz = TimeSpan.FromSeconds(dto.Timezone);

        DateTimeOffset FromUnixLocal(long seconds) =>
            DateTimeOffset.FromUnixTimeSeconds(seconds).ToOffset(tz);

        var first = dto.Weather.FirstOrDefault();

        return new WeatherSnapshot(
            city: dto.Name ?? "Unknown",
            description: dto.Weather[0].Description ?? "Unknown",
            country: dto.Sys?.Country,
            location: new GeoPoint(dto.Coord.Lat, dto.Coord.Lon),

            temperature: dto.Main.Temp,
            feelsLikeTemperature: dto.Main.FeelsLike,
            minTemperature: dto.Main.TempMin,
            maxTemperature: dto.Main.TempMax,

            pressureHpa: dto.Main.Pressure,
            humidityPercent: dto.Main.Humidity,

            windSpeedMs: dto.Wind?.Speed ?? 0,
            windDeg: dto.Wind?.Deg ?? 0,
            windGustMs: dto.Wind?.Gust,

            cloudinessPercent: dto.Clouds?.All ?? 0,

            observedAt: FromUnixLocal(dto.Dt),
            sunriseLocal: dto.Sys?.Sunrise is long sr ? FromUnixLocal(sr) : null,
            sunsetLocal:  dto.Sys?.Sunset  is long ss ? FromUnixLocal(ss) : null,

            condition: MapCondition(first?.Main)
        );
    }

    private static WeatherCondition MapCondition(string? main) => main?.ToLowerInvariant() switch
    {
        "clear"        => WeatherCondition.Clear,
        "clouds"       => WeatherCondition.Clouds,
        "rain"         => WeatherCondition.Rain,
        "drizzle"      => WeatherCondition.Drizzle,
        "thunderstorm" => WeatherCondition.Thunderstorm,
        "snow"         => WeatherCondition.Snow,
        "mist"         => WeatherCondition.Mist,
        "fog"          => WeatherCondition.Fog,
        "haze"         => WeatherCondition.Haze,
        "dust"         => WeatherCondition.Dust,
        "smoke"        => WeatherCondition.Smoke,
        "sand"         => WeatherCondition.Sand,
        "ash"          => WeatherCondition.Ash,
        "squall"       => WeatherCondition.Squall,
        "tornado"      => WeatherCondition.Tornado,
        _              => WeatherCondition.Unknown
    };
}