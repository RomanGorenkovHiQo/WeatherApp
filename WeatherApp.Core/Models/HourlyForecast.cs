namespace WeatherApp.Core.Models;

public class HourlyForecast
{
    public DateTime Time { get; init; }
    public string Condition { get; init; } = "clouds";
    public double TemperatureC { get; init; }
}