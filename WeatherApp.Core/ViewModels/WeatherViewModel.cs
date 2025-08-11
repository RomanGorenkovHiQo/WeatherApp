using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherApp.Core.Models;

namespace WeatherApp.Core.ViewModels;

public class WeatherViewModel : INotifyPropertyChanged
{
    double _tempC = -1, _feelsC = -4, _windMs = 5.14, _minC = -1, _maxC = 3;
    string _city = "Helsinki", _condition = "snow";

    public string City { get => _city; set { _city = value; OnPropertyChanged(); } }
    public string Condition { get => _condition; set { _condition = value; OnPropertyChanged(); } }
    public double TemperatureC { get => _tempC; set { _tempC = value; OnPropertyChanged(); } }
    public double FeelsLikeC { get => _feelsC; set { _feelsC = value; OnPropertyChanged(); } }
    public double WindMs { get => _windMs; set { _windMs = value; OnPropertyChanged(); } }
    public double MinC { get => _minC; set { _minC = value; OnPropertyChanged(); } }
    public double MaxC { get => _maxC; set { _maxC = value; OnPropertyChanged(); } }
    public DateTime LocalTime { get; set; } = DateTime.Now;

    public ObservableCollection<HourlyForecast> Hourly { get; } = new();

    public WeatherViewModel()
    {
        Hourly.Add(new() { Time = DateTime.Today.AddHours(9),  Condition = "snow",      TemperatureC = -1 });
        Hourly.Add(new() { Time = DateTime.Today.AddHours(12), Condition = "drizzle",   TemperatureC = 0  });
        Hourly.Add(new() { Time = DateTime.Today.AddHours(15), Condition = "clouds",    TemperatureC = 1  });
        Hourly.Add(new() { Time = DateTime.Today.AddHours(18), Condition = "clear",     TemperatureC = 3  });
        Hourly.Add(new() { Time = DateTime.Today.AddHours(21), Condition = "mist",      TemperatureC = 2  });
        Hourly.Add(new() { Time = DateTime.Today.AddHours(24), Condition = "thunder",   TemperatureC = 1  });
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string? n = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

}