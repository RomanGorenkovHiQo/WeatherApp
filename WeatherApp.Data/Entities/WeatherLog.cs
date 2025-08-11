using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Data.Entities;

public class WeatherLog
{
    [Key]
    public int Id { get; set; }

    public string City { get; set; }

    public DateTime Timestamp { get; set; }

    public string RawJson { get; set; }
}