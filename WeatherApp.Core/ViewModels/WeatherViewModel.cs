using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherApp.Core.Models;
using WeatherApp.Core.Models.Weather;

namespace WeatherApp.Core.ViewModels;

public class WeatherViewModel : INotifyPropertyChanged
{
    private CurrentWeather _currentWeather;
    
    public CurrentWeather CurrentWeather
    {
        get => _currentWeather;
        set
        {
            _currentWeather = value;
            OnPropertyChanged(nameof(CurrentWeather));
        }
    }
    public DateTime LocalTime { get; set; } = DateTime.Now;

    public ObservableCollection<HourlyForecast> Hourly { get; } = new();

    public WeatherViewModel()
    {
        Hourly.Add(new() {Time = DateTime.Today.AddHours(9), Condition = "snow", TemperatureC = -1});
        Hourly.Add(new() {Time = DateTime.Today.AddHours(12), Condition = "drizzle", TemperatureC = 0});
        Hourly.Add(new() {Time = DateTime.Today.AddHours(15), Condition = "clouds", TemperatureC = 1});
        Hourly.Add(new() {Time = DateTime.Today.AddHours(18), Condition = "clear", TemperatureC = 3});
        Hourly.Add(new() {Time = DateTime.Today.AddHours(21), Condition = "mist", TemperatureC = 2});
        Hourly.Add(new() {Time = DateTime.Today.AddHours(24), Condition = "thunder", TemperatureC = 1});
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string? n = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
}