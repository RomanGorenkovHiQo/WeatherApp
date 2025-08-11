using System.Windows.Input;
using WeatherApp.Core.Common;
using WeatherApp.Core.Interfaces;

namespace WeatherApp.Core.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IOpenWeatherService _weatherService;

    private string _weatherText;
    public string WeatherText
    {
        get => _weatherText;
        set => SetProperty(ref _weatherText, value);
    }

    public ICommand LoadWeatherCommand { get; }

    public MainViewModel(IOpenWeatherService weatherService)
    {
        _weatherService = weatherService;
        LoadWeatherCommand = new DelegateCommand(async () => await LoadWeatherAsync());
    }

    private async Task LoadWeatherAsync()
    {
        try
        {
            var result = await _weatherService.GetWeatherByCityAsync("Minsk");
            WeatherText = $"Temp: {result.main.temp}°C\n" +
                          $"Description: {result.weather[0].description}";
        }
        catch (Exception ex)
        {
            WeatherText = $"Error: {ex.Message}";
        }
    }
}