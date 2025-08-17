using System.Windows.Input;
using WeatherApp.Core.Common;
using WeatherApp.Core.Interfaces;

namespace WeatherApp.Core.ViewModels;

public class MainViewModel : ViewModelBase
{
    private string _query;
    private WeatherViewModel _weather;
    private bool _isBusy;
    private string _error;
    
    public string Query
    {
        get => _query; 
        set {
            if (_query != value)
            {
                _query=value; OnPropertyChanged(nameof(Query));
            }}
    }
    
    public WeatherViewModel Weather
    {
        get => _weather;
        set {
            if (_weather != value)
            {
                _weather=value; OnPropertyChanged(nameof(Weather));
            }}
    }
    public bool IsBusy { 
        get => _isBusy;
        set {
            if (_isBusy != value)
            {
                _isBusy=value; OnPropertyChanged(nameof(IsBusy));
            }} }
    
    public string Error
    {
        get => _error; 
        set {
            if (_error != value)
            {
                _error=value; OnPropertyChanged(nameof(Error));
            }}
    }
    
    public ICommand SearchCommand { get; }
    
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
        // LoadWeatherCommand = new DelegateCommand(async () => await LoadWeatherAsync());
        SearchCommand = new DelegateCommand<string>(async q => await SearchAsync(q));
    
    }
    //
    // private async Task LoadWeatherAsync()
    // {
    //     try
    //     {
    //         // var result = await _weatherService.GetWeatherByCityAsync("Minsk");
    //         // WeatherText = $"Temp: {result.main.temp}°C\n" +
    //         //               $"Description: {result.weather[0].description}";
    //     }
    //     catch (Exception ex)
    //     {
    //         WeatherText = $"Error: {ex.Message}";
    //     }
    // }
    //
    private async Task SearchAsync(string query)
    {
        try
        {
            IsBusy = true;
            Error = null;
            Query = query ?? Query;
    
            var weatherData = await _weatherService.GetWeatherByCityAsync(Query);
            var currentWeather = new WeatherViewModel()
            {
                CurrentWeather = weatherData
            };
            Weather = currentWeather;
        }
        catch (Exception)
        {
            Error = "Error";
        }
        finally
        {
            IsBusy = false;
        }
    }
}