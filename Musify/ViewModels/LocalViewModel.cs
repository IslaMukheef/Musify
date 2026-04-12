using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Musify.Models;

namespace Musify.ViewModels;

/// <summary>
/// Manages the logic for selecting local audio files and pushing them to the global library.
/// </summary>
public class LocalViewModel : INotifyPropertyChanged
{
    private LibraryData _library;
    public ObservableCollection<Song> PickedSongs { get; set; } = new();

    /// <summary>
    /// Initializes the ViewModel with a specific LibraryData instance.
    /// </summary>
    public LocalViewModel(LibraryData library)
    {
        _library = library;
    }
    
    /// <summary>
    /// Opens the system file picker to select MP3 files and adds them to the global library collection.
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
                    
                    // Add to the local UI list for immediate feedback
                    PickedSongs.Add(newSong);

                    // NEW LOGIC: Pushing the song to the shared Library so it shows up globally
                    _library.Songs.Add(newSong);
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