using System.Text.Json;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Models.Weather;
using WeatherApp.Core.Settings;
using WeatherApp.Core.ViewModels;


namespace WeatherApp.Core.Services;

public class OpenWeatherService : IOpenWeatherService
{
    private readonly OpenWeatherSettings _settings;
    // private readonly WeatherDbContext _db;
    private readonly IWeatherApiClient _api;

    public OpenWeatherService( IWeatherApiClient api)
    {
        // _httpClient = new HttpClient();
        // _settings = settings;
        // _db = db;
        _api = api;
    }

    // public async Task<WeatherResponse> GetWeatherByCityAsync(string city)
    // {
    //     var weather = await _api.GetCurrentAsync(city);   
    //
    //     var log = new WeatherLog
    //     {
    //         City = weather.City,
    //         Timestamp = DateTime.Now,
    //         RawJson = json
    //     };
    //
    //     _db.WeatherLogs.Add(log);
    //     await _db.SaveChangesAsync();
    //
    //     var options = new JsonSerializerOptions
    //     {
    //         PropertyNameCaseInsensitive = true
    //     };
    //
    //     return JsonSerializer.Deserialize<WeatherResponse>(json, options)!;
    // }
    
    public async Task<CurrentWeather> GetWeatherByCityAsync(string city)
    {
        var weatherData = await _api.GetCurrentAsync(city);
        var currentWeather = new CurrentWeather(
            weatherData.City,
            weatherData.Temperature,
            weatherData.FeelsLikeTemperature,
            weatherData.Description,
            weatherData.WindSpeedMs,
            weatherData.MinTemperature,
            weatherData.MaxTemperature
            
            );
        return currentWeather;
    }
}