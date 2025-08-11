using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WeatherApp.Core.Interfaces;
using WeatherApp.Core.Services;
using WeatherApp.Core.Settings;
using WeatherApp.Core.ViewModels;
using WeatherApp.Data.Db;
using WeatherApp.Data.Repositories;
using WeatherApp.Data.Services;

namespace WeatherApp.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        var apiKey = "1235c3db009907307820169432d978db";
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "weather.db");

        builder.Services.AddDbContext<WeatherDbContext>(options =>
            options.UseSqlite($"Data Source={dbPath}"));
        
        var weatherSettings = new OpenWeatherSettings
        {
            ApiKey = apiKey
        };
        
        builder.Services.AddSingleton(weatherSettings);
        builder.Services.AddSingleton<IOpenWeatherService, OpenWeatherService>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddSingleton<WeatherViewModel>();
        
        

        return builder.Build();
    }
}