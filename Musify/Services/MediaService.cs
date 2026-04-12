using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;
using Musify.Models;

namespace Musify.Services;

public static class MediaService
{
    private static MediaElement? _mediaElement;
    
    // The song currently loaded into the player
    public static Song? CurrentSong { get; private set; }

    /// <summary>
    /// Links the global service to the actual MediaElement sitting in the UI.
    /// </summary>
    public static void Initialize(MediaElement mediaElement)
    {
        _mediaElement = mediaElement;
    }

    /// <summary>
    /// Loads and plays a song. This is what you'll call from your "Tapped" events.
    /// </summary>
    public static void Play(Song song)
    {
        if (_mediaElement == null || string.IsNullOrEmpty(song.LocalPath)) return;

        CurrentSong = song;
        
        // Use the LocalPath we saved during the file pick
        _mediaElement.Source = MediaSource.FromFile(song.LocalPath);
        _mediaElement.Play();
    }

    public static void TogglePlayback()
    {
        if (_mediaElement == null) return;

        if (_mediaElement.CurrentState == MediaElementState.Playing)
            _mediaElement.Pause();
        else
            _mediaElement.Play();
    }

    public static void Stop()
    {
        _mediaElement?.Stop();
    }
}