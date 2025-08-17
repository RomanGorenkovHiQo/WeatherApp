using System.Text.Json.Serialization;

namespace WeatherApp.Data.Models.OpenWeather;

public sealed class WeatherResponseDto
{
    [JsonPropertyName("coord")] public CoordDto Coord { get; init; } = default!;
    [JsonPropertyName("weather")] public List<WeatherDto> Weather { get; init; } = new();
    [JsonPropertyName("base")] public string? Base { get; init; }
    [JsonPropertyName("main")] public MainDto Main { get; init; } = default!;
    [JsonPropertyName("visibility")] public int? Visibility { get; init; }
    [JsonPropertyName("wind")] public WindDto? Wind { get; init; }
    [JsonPropertyName("clouds")] public CloudsDto? Clouds { get; init; }
    [JsonPropertyName("dt")] public long Dt { get; init; }            // Unix seconds (UTC)
    [JsonPropertyName("sys")] public SysDto? Sys { get; init; }
    [JsonPropertyName("timezone")] public int Timezone { get; init; } // shift in seconds
    [JsonPropertyName("id")] public int? CityId { get; init; }
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("cod")] public int? Cod { get; init; }
}

public sealed class CoordDto
{
    [JsonPropertyName("lon")] public double Lon { get; init; }
    [JsonPropertyName("lat")] public double Lat { get; init; }
}

public sealed class WeatherDto
{
    [JsonPropertyName("id")] public int Id { get; init; }
    [JsonPropertyName("main")] public string Main { get; init; } = "";
    [JsonPropertyName("description")] public string Description { get; init; } = "";
    [JsonPropertyName("icon")] public string Icon { get; init; } = "";
}

public sealed class MainDto
{
    [JsonPropertyName("temp")] public double Temp { get; init; }
    [JsonPropertyName("feels_like")] public double FeelsLike { get; init; }
    [JsonPropertyName("temp_min")] public double TempMin { get; init; }
    [JsonPropertyName("temp_max")] public double TempMax { get; init; }
    [JsonPropertyName("pressure")] public int Pressure { get; init; }       // hPa
    [JsonPropertyName("humidity")] public int Humidity { get; init; }       // %
    [JsonPropertyName("sea_level")] public int? SeaLevel { get; init; }     // hPa (nullable)
    [JsonPropertyName("grnd_level")] public int? GroundLevel { get; init; } // hPa (nullable)
}

public sealed class WindDto
{
    [JsonPropertyName("speed")] public double Speed { get; init; } // m/s
    [JsonPropertyName("deg")] public int Deg { get; init; }
    [JsonPropertyName("gust")] public double? Gust { get; init; }  // m/s
}

public sealed class CloudsDto
{
    [JsonPropertyName("all")] public int All { get; init; } // %
}

public sealed class SysDto
{
    [JsonPropertyName("country")] public string? Country { get; init; }
    [JsonPropertyName("sunrise")] public long? Sunrise { get; init; } // Unix seconds (UTC)
    [JsonPropertyName("sunset")] public long? Sunset { get; init; }   // Unix seconds (UTC)
}