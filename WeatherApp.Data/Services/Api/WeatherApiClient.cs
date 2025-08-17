using System.Net.Http.Json;
using System.Text.Json;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Models.Weather;
using WeatherApp.Data.Mappers;
using WeatherApp.Data.Models.OpenWeather;

namespace WeatherApp.Data.Services.Api;

public sealed class WeatherApiClient( JsonSerializerOptions? jsonOptions = null) : IWeatherApiClient 
{
    private readonly HttpClient _http = new HttpClient();
    private readonly JsonSerializerOptions _json = jsonOptions ?? new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<WeatherSnapshot?> GetCurrentAsync(string cityName)
    {
        const string apiKey = "";
        const string lang = "en";
        const string units = "metric";
        var url = $"data/2.5/weather?q={cityName}&appid={apiKey}&lang={lang}&units={units}";
        var data = await _http.GetFromJsonAsync<WeatherResponseDto>(url, _json);
        return data.ToDomain();
    }
}