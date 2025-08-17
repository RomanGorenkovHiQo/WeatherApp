using WeatherApp.UI.Interfaces;

namespace WeatherApp.UI.Services;

public class NavigationService : INavigationService
{
    readonly IServiceProvider _sp;
    
    public NavigationService(IServiceProvider sp) => _sp = sp;

    INavigation? CurrentNav =>
        (Application.Current?.MainPage as NavigationPage)?.Navigation
        ?? Application.Current?.MainPage?.Navigation;

    public Task<Page?> GetCurrentPageAsync() =>
        Task.FromResult(CurrentNav?.NavigationStack.LastOrDefault());

    public Task PopAsync() => CurrentNav?.PopAsync() ?? Task.CompletedTask;
    public Task PopModalAsync() => CurrentNav?.PopModalAsync() ?? Task.CompletedTask;

    public Task PushAsync<TPage>() where TPage : Page =>
        CurrentNav?.PushAsync(_sp.GetRequiredService<TPage>()) ?? Task.CompletedTask;

    public Task PushModalAsync<TPage>() where TPage : Page =>
        CurrentNav?.PushModalAsync(_sp.GetRequiredService<TPage>()) ?? Task.CompletedTask;
}