using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;
using Musify.Models;

namespace Musify.Services;

/// <summary>
/// A static service that acts as the global controller
/// for audio playback across the application
/// </summary>
public static class MediaService
{
    // Media Element instance
    private static MediaElement? _mediaElement;
    
    // current song loaded in player
    public static Song? CurrentSong { get; private set; }

    // gets total length of current song
    public static TimeSpan Duration => _mediaElement?.Duration ?? TimeSpan.Zero;
    // gets playback position of current
    public static TimeSpan Position => _mediaElement?.Position ?? TimeSpan.Zero;
    
    // checks if song is playing
    public static bool IsPlaying => _mediaElement?.CurrentState == MediaElementState.Playing;

    /// <summary>
    /// Connects a UI-based MediaElement to this service to enable global control.
    /// </summary>
    /// <param name="mediaElement">The MediaElement instance to be controlled.</param>
    public static void Initialize(MediaElement mediaElement)
    {
        _mediaElement = mediaElement;
    }
    
    /// <summary>
    /// Loads an audio file from the local file system and begins playback immediately.
    /// </summary>
    /// <param name="song">Song object containing local file path to play</param>
    public static void Play(Song song)
    {
        if (_mediaElement == null || string.IsNullOrEmpty(song.LocalPath)) return;

        CurrentSong = song;
        _mediaElement.Source = MediaSource.FromFile(song.LocalPath);
        _mediaElement.Play();
    }
    
    /// <summary>
    /// Toggles between Playing and Paused states
    /// depending on the current status of the player.
    /// </summary>
    public static void TogglePlayback()
    {
        if (_mediaElement == null) return;

        if (_mediaElement.CurrentState == MediaElementState.Playing)
            _mediaElement.Pause();
        else
            _mediaElement.Play();
    }
    
    /// <summary>
    /// Moves the playback position to a specific
    /// timestamp within the current song.
    /// </summary>
    /// <param name="position">Target TimeSpan to seek to.</param>
    public static void Seek(TimeSpan position)
    {
        _mediaElement?.SeekTo(position);
    }
    
    /// <summary>
    /// Stops & resets playback & position of current audio
    /// </summary>
    public static void Stop()
    {
        _mediaElement?.Stop();
    }
}