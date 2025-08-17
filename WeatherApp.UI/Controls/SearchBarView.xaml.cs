using System.Windows.Input;

namespace WeatherApp.UI.Controls;

public partial class SearchBarView : ContentView
{
    public static readonly BindableProperty QueryProperty =
        BindableProperty.Create(nameof(Query), typeof(string), typeof(SearchBarView), string.Empty, BindingMode.TwoWay);

    public static readonly BindableProperty SearchCommandProperty =
        BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(SearchBarView));

    public string Query
    {
        get => (string)GetValue(QueryProperty);
        set => SetValue(QueryProperty, value);
    }

    public ICommand SearchCommand
    {
        get => (ICommand)GetValue(SearchCommandProperty);
        set => SetValue(SearchCommandProperty, value);
    }

    public SearchBarView()
    {
        InitializeComponent();
    }

    private void OnEntryCompleted(object sender, EventArgs e)
    {
        if (SearchCommand?.CanExecute(Query) ?? false)
            SearchCommand.Execute(Query);
    }
}