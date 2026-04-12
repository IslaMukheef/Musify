using Musify.Services;

namespace Musify.Views;

public partial class Home : ContentPage
{
    public Home()
    {
        InitializeComponent();
        
        // Connects global service to the element on this page
        MediaService.Initialize(GlobalMediaElement);
    }

    private async void OnHomeSearchBarFocused(object? sender, FocusEventArgs e)
    {
        await Navigation.PushAsync(new Search());
    }
}