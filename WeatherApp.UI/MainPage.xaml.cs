using WeatherApp.Core.ViewModels;

namespace WeatherApp.UI;

public partial class MainPage : ContentPage
{
    public WeatherViewModel Weather { get; }

    public MainPage(MainViewModel viewModel, WeatherViewModel vm)
    {
        Weather = vm;
        InitializeComponent();
        BindingContext = viewModel;
    }
}