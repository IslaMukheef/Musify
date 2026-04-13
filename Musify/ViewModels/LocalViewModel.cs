using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Musify.Models;

namespace Musify.ViewModels;

/// <summary>
/// Handles the selection of local audio files and synchronizes them with the application's global library.
/// </summary>
public class LocalViewModel : INotifyPropertyChanged
{
    private LibraryData _library;
    private string _statusMessage = "No files selected";

    // New properties to help the View show alerts
    public int LastNewCount { get; private set; }
    public int LastDupeCount { get; private set; }

    /// <summary>
    /// Gets the collection of songs picked
    /// during the current session for UI feedback
    /// </summary>
    public ObservableCollection<Song> PickedSongs { get; set; } = new();

    /// <summary>
    /// Gets or sets the message displayed to the user
    /// for the current state of the import process
    /// </summary>
    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            _statusMessage = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Initializes a new instance of the view model
    /// and links it to the shared global library
    /// </summary>
    /// <param name="library">Global LibraryData instance used across the app.</param>
    public LocalViewModel(LibraryData library)
    {
        _library = library;
    }
    
    /// <summary>
    /// Triggers the system file picker to select audio files, strips extensions, 
    /// and adds the resulting songs to both the local view and the global library.
    /// </summary>
    public async Task PickMusicFiles()
    {
        try
        {
            // Reset counters for the new pick session
            LastNewCount = 0;
            LastDupeCount = 0;

            // Defines supported audio types for cross-platform compatibility
            var audioFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.audio", "public.mp3" } },
                    { DevicePlatform.MacCatalyst, new[] { "public.audio", "public.mp3" } },
                    { DevicePlatform.Android, new[] { "audio/*" } },
                    { DevicePlatform.WinUI, new[] { ".mp3", ".wav", ".m4a" } }
                });

            var results = await FilePicker.Default.PickMultipleAsync(new PickOptions
            {
                PickerTitle = "Select Music Files",
                FileTypes = audioFileType
            });

            if (results != null && results.Any())
            {
                // We no longer Clear() here so the "upload history" stays visible

                foreach (var file in results)
                {
                    // Clean title by removing file extensions (e.g., .mp3)
                    var cleanTitle = Path.GetFileNameWithoutExtension(file.FileName);

                    // Check if this song title already exists in the global library (case-insensitive)
                    bool alreadyInLibrary = false;
                    foreach (var existingSong in _library.Songs)
                    {
                        if (existingSong.Title.ToLower() == cleanTitle.ToLower())
                        {
                            alreadyInLibrary = true;
                            break;
                        }
                    }

                    // Only add the song if it's not already there
                    if (alreadyInLibrary == false)
                    {
                        var newSong = new Song(
                            cleanTitle,
                            "Local Artist",
                            "Local Album",
                            string.Empty,
                            file.FullPath,
                            string.Empty,
                            0,
                            "local_background.png"
                        );
                        
                        // Sync with UI list and the global data store
                        PickedSongs.Add(newSong);
                        _library.Songs.Add(newSong);
                        LastNewCount++;
                    }
                    else
                    {
                        // Track how many were actually skipped
                        LastDupeCount++;
                    }
                }

                // --- FIXED STATUS MESSAGE LOGIC ---
                if (LastNewCount > 0 && LastDupeCount > 0)
                {
                    StatusMessage = $"Added {LastNewCount} songs ({LastDupeCount} duplicates skipped)";
                }
                else if (LastNewCount > 0)
                {
                    StatusMessage = $"Successfully imported {LastNewCount} new songs!";
                }
                else if (LastDupeCount > 0)
                {
                    StatusMessage = "All files were already in your library.";
                }
            }
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}