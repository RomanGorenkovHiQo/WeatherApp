namespace WeatherApp.Data.Models.OpenWeather;

public class WeatherResponse
{
    public Main main { get; set; }
    public List<Weather> weather { get; set; }
    public string name { get; set; }
}

public class Main
{
    public double temp { get; set; }
    public double feels_like { get; set; }
}

public class Weather
{
    public string description { get; set; }
    public string icon { get; set; }
}