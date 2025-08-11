using System.Text.Json;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Settings;
using WeatherApp.Data.Db;
using WeatherApp.Data.Entities;
using WeatherApp.Data.Models.OpenWeather;

namespace WeatherApp.Core.Services;

public class OpenWeatherService : IOpenWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly OpenWeatherSettings _settings;
    private readonly WeatherDbContext _db;

    public OpenWeatherService(OpenWeatherSettings settings, WeatherDbContext db)
    {
        _httpClient = new HttpClient();
        _settings = settings;
        _db = db;
    }

    public async Task<WeatherResponse> GetWeatherByCityAsync(string city)
    {
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_settings.ApiKey}&units=metric&lang=ru";

        var response = await _httpClient.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception("Error OpenWeather");

        var log = new WeatherLog
        {
            City = city,
            Timestamp = DateTime.Now,
            RawJson = json
        };

        _db.WeatherLogs.Add(log);
        await _db.SaveChangesAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<WeatherResponse>(json, options)!;
    }
}