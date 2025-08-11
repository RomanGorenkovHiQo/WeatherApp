using System.Globalization;

namespace WeatherApp.UI.Converters;

public sealed class ConditionToIconConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value switch
        {
            "snow" => "snow.png",
            "drizzle" => "drizzle.png",
            "clouds" => "clouds.png",
            "clear" => "clear.png",
            "mist" => "mist.png",
            "thunder" => "thunder.png",
            _ => "clouds.png"
        };

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}

public sealed class ConditionToTitleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value?.ToString() switch
        {
            "snow" => "Snow",
            "drizzle" => "Drizzle",
            "clouds" => "Clouds",
            "clear" => "Clear",
            "mist" => "Mist",
            "thunder" => "Thunderstorm",
            _ => "—"
        };
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}