using Microsoft.EntityFrameworkCore;
using WeatherApp.Data.Db;
using WeatherApp.Data.Entities;

namespace WeatherApp.Data.Repositories;

public class WeatherRepository : IWeatherRepository
{
    private readonly WeatherDbContext _context;

    public WeatherRepository(WeatherDbContext context)
    {
        _context = context;
    }

    public async Task<List<WeatherEntry>> GetAllAsync()
    {
        return await _context.WeatherEntries.ToListAsync();
    }

    public async Task AddAsync(WeatherEntry entry)
    {
        _context.WeatherEntries.Add(entry);
        // await _context.SaveChangesAsync();
    }
}