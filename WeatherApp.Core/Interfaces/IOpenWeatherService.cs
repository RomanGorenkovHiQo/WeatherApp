using WeatherApp.Core.Models.Weather;
using WeatherApp.Core.ViewModels;

namespace WeatherApp.Core.Interfaces;

public interface IOpenWeatherService
{
    Task<CurrentWeather> GetWeatherByCityAsync(string city);
}