using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Musify.Models;
using Musify.Services; 

namespace Musify.ViewModels;

/// <summary>
/// Manages the logic for selecting and playing local audio files.
/// </summary>
public class LocalViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Song> PickedSongs { get; set; } = new();

    /// <summary>
    /// Sends the selected song to the MediaHelper for playback.
    /// </summary>
    /// <param name="song">The song object to be played.</param>
    public void PlaySong(Song? song)
    {
        if (song != null)
        {
            MediaHelper.Play(song.LocalPath);
        }
    }
    
    /// <summary>
    /// Opens the system file picker to select MP3 files and adds them to the local collection.
    /// </summary>
    public async Task PickMusicFiles()
    {
        try
        {
            var audioFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.audio", "public.mp3" } },
                    { DevicePlatform.MacCatalyst, new[] { "public.audio", "public.mp3" } }
                });

            var results = await FilePicker.Default.PickMultipleAsync(new PickOptions
            {
                PickerTitle = "Select Music Files",
                FileTypes = audioFileType
            });

            
            if (results != null)
            {
                foreach (var file in results)
                {
                    // Replaced 'null' with 'string.Empty' to match the non-nullable Song constructor
                    var newSong = new Song(
                        file.FileName, 
                        "Local Artist", 
                        "Local Album", 
                        string.Empty, 
                        file.FullPath, 
                        string.Empty, 
                        0, 
                        "dotnet_bot.png" 
                    );
                    
                    PickedSongs.Add(newSong);
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Picker failed: {ex.Message}");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}