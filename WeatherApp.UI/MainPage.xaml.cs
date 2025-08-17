using System.ComponentModel;
using System.Windows.Input;
using WeatherApp.Core.ViewModels;

namespace WeatherApp.UI;

public partial class MainPage : ContentPage
{

    // public WeatherViewModel Weather { get; }

    public MainPage(MainViewModel viewModel)
    // public MainPage()
    {
        InitializeComponent();
        // BindingContext = viewModel;
    }
}