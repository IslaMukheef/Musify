using Musify.ViewModels;
using Musify.Models;

namespace Musify.Views;

public partial class LocalView : ContentPage
{
    private LocalViewModel _viewModel;

    public LocalView()
    {
        InitializeComponent();
        // Pass the shared library into the viewmodel for global sync
        _viewModel = new LocalViewModel(App.SharedLibrary);
        BindingContext = _viewModel;
    }

    private async void OnSelectFilesClicked(object? sender, EventArgs e)
    {
        await _viewModel.PickMusicFiles();
    }

    private async void OnSongTapped(object? sender, TappedEventArgs e)
    {
        if (sender is Border tappedBorder)
        {
            await tappedBorder.FadeToAsync(0.6, 50); 
            await tappedBorder.FadeToAsync(1.0, 50);
        }
    }
}