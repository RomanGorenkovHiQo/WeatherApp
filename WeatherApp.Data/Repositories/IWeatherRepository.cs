using WeatherApp.Data.Entities;

namespace WeatherApp.Data.Repositories;

public interface IWeatherRepository
{
    Task<List<WeatherEntry>> GetAllAsync();
    Task AddAsync(WeatherEntry entry);
}