using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Core;
using System.Diagnostics;

namespace Musify.Services;

public static class MediaHelper
{
    /// <summary>
    /// Instace of the Global Media Player
    /// </summary>
    public static MediaElement? Player { get; set; }

    /// <summary>
    /// Plays an audio file from a local file path. 
    /// Stops any current playback and switches the source to the new file.
    /// </summary>
    /// <param name="filePath">The full system path to the audio file.</param>
    public static void Play(string filePath)
    {
        if (Player == null || string.IsNullOrWhiteSpace(filePath)) return;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            try 
            {
                Player.Stop();
                Player.Source = MediaSource.FromFile(filePath);
                Player.Play();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Playback Error: {ex.Message}");
            }
        });
    }

    /// <summary>
    /// Toggles the player between Playing and Paused states.
    /// If the player is currently playing, it will pause. Otherwise, it will resume.
    /// </summary>
    public static void TogglePlayback()
    {
        if (Player == null) return;

        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (Player.CurrentState == MediaElementState.Playing)
            {
                Player.Pause();
            }
            else
            {
                Player.Play();
            }
        });
    }

    /// <summary>
    /// *Explicitly* pauses the selected audio playback.
    /// </summary>
    public static void Pause() => MainThread.BeginInvokeOnMainThread(() => Player?.Pause());

    /// <summary>
    /// *Explicitly* resumes the selected audio playback.
    /// </summary>
    public static void Resume() => MainThread.BeginInvokeOnMainThread(() => Player?.Play());
}