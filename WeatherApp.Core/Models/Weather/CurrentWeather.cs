namespace WeatherApp.Core.Models.Weather;

public class CurrentWeather
{
    public string City { get; }
    public double Temperature { get; }
    public double FeelsLikeTemperature { get; }
    public string Condition { get; }
    public double WindMs { get; }
    public double MinTemperature { get; }
    public double MaxTemperature { get; }

    public CurrentWeather(
        string city,
        double temperature,
        double feelsLikeTemperature,
        string condition,
        double windMs,
        double minTemperature,
        double maxTemperature
        )
    {
        City = city;
        Temperature = temperature;
        FeelsLikeTemperature = feelsLikeTemperature;
        Condition = condition;
        WindMs = windMs;
        MinTemperature = minTemperature;
        MaxTemperature = maxTemperature;
    }
}