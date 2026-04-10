namespace Musify.Views;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
    }

    private async void OnHomeSearchBarFocused(object? sender, FocusEventArgs e)
    {
        await Navigation.PushAsync(new Search());
    }
}
