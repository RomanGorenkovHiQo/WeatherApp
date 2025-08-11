using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Data.Entities;

public class WeatherEntry
{
    [Key]
    public int Id { get; set; }

    public string City { get; set; }

    public string Condition { get; set; }

    public double Temperature { get; set; }

    public DateTime Date { get; set; }
}