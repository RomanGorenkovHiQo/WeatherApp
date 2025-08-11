using SQLite;
using WeatherApp.Data.Entities;
using WeatherApp.Data.Models;

namespace WeatherApp.Data.Services;

public class WeatherDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public WeatherDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<WeatherEntry>().Wait();
    }

    public Task<List<WeatherEntry>> GetEntriesAsync()
    {
        return _database.Table<WeatherEntry>().ToListAsync();
    }

    public Task<int> SaveEntryAsync(WeatherEntry entry)
    {
        if (entry.Id != 0)
            return _database.UpdateAsync(entry);
        else
            return _database.InsertAsync(entry);
    }

    public Task<int> DeleteEntryAsync(WeatherEntry entry)
    {
        return _database.DeleteAsync(entry);
    }
}