using WeatherApp.Core.Models.Weather;

namespace WeatherApp.Core.Interfaces;

public interface IWeatherApiClient
{
    public Task<WeatherSnapshot?> GetCurrentAsync(string cityName);
}