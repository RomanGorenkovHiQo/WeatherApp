using Microsoft.EntityFrameworkCore;
using WeatherApp.Data.Entities;

namespace WeatherApp.Data.Db;

public class WeatherDbContext : DbContext
{
    public DbSet<WeatherEntry> WeatherEntries { get; set; }
    public DbSet<WeatherLog> WeatherLogs { get; set; }

    public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}