using Musify.Models;
using Musify.Services;

namespace Musify.Views;

/// <summary>
/// Provides the full-screen interface for music playback,
/// including controls and progress tracking.
/// </summary>
public partial class SongPlayerView : ContentPage
{
    // Checks if user is dragging slider
    private bool _isDragging = false;

    // Background timer to refresh playback periodically
    private IDispatcherTimer _timer;

    /// <summary>
    /// Initializes a new instance of the player for a specific song and starts the progress tracker.
    /// </summary>
    /// <param name="selectedSong">The song object to be displayed and played.</param>
    public SongPlayerView(Song selectedSong)
    {
        InitializeComponent();
        BindingContext = selectedSong;

        // Start with pause icon since music starts automatically
        PlayPauseBtn.Source = "pause_circle.png";
        
        // Handles slider timer - runs every 500ms for smooth updates
        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromMilliseconds(500);
        _timer.Tick += (s, e) => UpdateProgress();
        _timer.Start();
    }

    /// <summary>
    /// Periodically syncs slider position
    /// and time labels with the global media service
    /// </summary>
    private void UpdateProgress()
    {
        if (_isDragging) return;

        var duration = MediaService.Duration;
        var position = MediaService.Position;

        if (duration > TimeSpan.Zero)
        {
            PositionSlider.Maximum = duration.TotalSeconds;
            PositionSlider.Value = position.TotalSeconds;

            // Uses "D2" format to force two digits for seconds (e.g. 0:05 instead of 0:5)
            CurrentTimeLabel.Text = $"{(int)position.TotalMinutes}:{position.Seconds:D2}";
            TotalTimeLabel.Text = $"{(int)duration.TotalMinutes}:{duration.Seconds:D2}";
        }
    }

    /// <summary>
    /// Confirms if user is dragging slider
    /// </summary>
    private void OnSliderDragStarted(object sender, EventArgs e)
    {
        _isDragging = true;
    }

    /// <summary>
    /// Confirms if user is done dragging slider
    /// </summary>
    private void OnSliderDragCompleted(object sender, EventArgs e)
    {
        var newPosition = TimeSpan.FromSeconds(PositionSlider.Value);
        MediaService.Seek(newPosition);
        _isDragging = false;
    }

    /// <summary>
    /// Stops the background timer and navigates back to the previous view
    /// </summary>
    private async void OnBackClicked(object sender, EventArgs e)
    {
        _timer.Stop();
        await Navigation.PopAsync();
    }

    /// <summary>
    /// Toggles the playback state via the MediaService
    /// and updates the UI button icon
    /// </summary>
    private void OnPlayPauseClicked(object sender, EventArgs e)
    {
        bool wasPlaying = MediaService.IsPlaying;
        MediaService.TogglePlayback();
        PlayPauseBtn.Source = wasPlaying ? "play_circle.png" : "pause_circle.png";
    }
    
    private void OnAddToPlaylistClicked(object sender, EventArgs e)
    {
        // TODO: Isla - Link this to your AddRemovePlaylistSongsView
    }

    private void OnArtistTapped(object sender, TappedEventArgs e)
    {
        // TODO: Isla - Link this to the Author Profile view
    }
}