using Musify.ViewModels;
using Musify.Models;

namespace Musify.Views;

public partial class LocalView : ContentPage
{
    /// <summary>
    /// Initially, Local view held media controls and playback
    /// capabilities for testing purposes, which is now removed.
    /// LocalView only allows pushing a Song from local to Library.
    /// Songs can then be controlled directly from the global media
    /// control or Song View.
    /// </summary>
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
        var button = sender as VisualElement;
        if (button != null)
        {
            // Upload File click feedback animation
            await button.ScaleTo(0.85, 80, Easing.CubicOut);
            await button.ScaleTo(1.0, 80, Easing.CubicIn);
        }

        // Run the pick logic
        await _viewModel.PickMusicFiles();

        // Check the results to show the right alert
        if (_viewModel.LastNewCount > 0)
        {
            string alertMsg = _viewModel.LastDupeCount > 0 
                ? $"Added {_viewModel.LastNewCount} songs. Skipped {_viewModel.LastDupeCount} duplicates." 
                : $"Successfully added {_viewModel.LastNewCount} songs!";

            await DisplayAlertAsync("Success", alertMsg, "Sweet");
        }
        else if (_viewModel.LastDupeCount > 0)
        {
            // This triggers if ONLY duplicates were picked
            await DisplayAlertAsync("Already In Library", "The files you selected are already in your library.", "OK");
        }
    }
}