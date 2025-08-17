namespace WeatherApp.UI.Interfaces;

public interface INavigationService
{
    Task PushAsync<TPage>() where TPage : Page;
    Task PushModalAsync<TPage>() where TPage : Page;
    Task PopAsync();
    Task PopModalAsync();
    Task<Page?> GetCurrentPageAsync();
}