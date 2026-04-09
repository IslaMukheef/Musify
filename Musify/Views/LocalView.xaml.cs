using Musify.ViewModels;
using Musify.Services;
using Musify.Models;

namespace Musify.Views;

public partial class LocalView : ContentPage
{
    private LocalViewModel _viewModel;

    public LocalView()
    {
        InitializeComponent();
        _viewModel = new LocalViewModel();
        BindingContext = _viewModel;

        // Connect the page-level player to the static helper
        MediaHelper.Player = LocalPlayer;
    }

    private async void OnSelectFilesClicked(object sender, EventArgs e)
    {
        await _viewModel.PickMusicFiles();
    }

    private void OnToggleClicked(object sender, EventArgs e)
    {
        // Removed the redundant .Stop() call as it was causing a null warning 
        // and would reset song progress anyway. 
        MediaHelper.TogglePlayback();
    }

    private async void OnSongTapped(object sender, TappedEventArgs e)
    {
        // Check for null and get the border/song data
        if (sender is Border tappedBorder && e.Parameter is Song selectedSong)
        {
            // Visual feedback: 'FadeToAsync' used to resolve obsolete warning CS0618
            await tappedBorder.FadeToAsync(0.6, 50); 
            await tappedBorder.FadeToAsync(1.0, 50);

            _viewModel.PlaySong(selectedSong);
        }
    }
}