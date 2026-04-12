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
        await _viewModel.PickMusicFiles();
    }
}