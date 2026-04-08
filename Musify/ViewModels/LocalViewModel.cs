using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Musify.Models;

namespace Musify.ViewModels;

public class LocalViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Song> PickedSongs { get; set; } = new();
    
    /// <summary>
    /// Music file picker allows user to select a local MP3 file
    /// to upload into their library. A new dictionary was created
    /// to handle audio files based on the in-use platform. Uploaded
    /// songs are then displayed in an Observable collection in the
    /// Local tab. This will be changed to push straight to library
    /// in a future update.
    /// </summary>
    public async Task PickMusicFiles()
    {
        try
        {
            var audioFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, new[] { "public.audio", "public.mp3" } },
                    { DevicePlatform.MacCatalyst, new[] { "public.audio", "public.mp3" } },
                    { DevicePlatform.WinUI, new[] { ".mp3", ".wav", ".m4a" } }
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
                    // Matches the Song constructor: title, artist, album, art, path, preview, duration, image
                    var newSong = new Song(
                        file.FileName, 
                        "Local Artist", 
                        "Local Album", 
                        null, 
                        file.FullPath, 
                        null, 
                        0, 
                        "dotnet_bot.png" 
                    );

                    PickedSongs.Add(newSong);
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"File picking failed: {ex.Message}");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}