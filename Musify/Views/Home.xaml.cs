namespace Musify.Views;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
    }

    private async void OnNavigateButtonClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new LibraryView());
    }

    private async void OnSearchButtonClicked(object? sender, EventArgs e)
    {
        await DisplayAlertAsync("Search", "Search screen will be added in the next task.", "OK");
    }
}
