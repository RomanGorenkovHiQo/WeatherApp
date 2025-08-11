using WeatherApp.Data.Models.OpenWeather;

namespace WeatherApp.Core.Interfaces;

public interface IOpenWeatherService
{
    Task<WeatherResponse> GetWeatherByCityAsync(string city);
}