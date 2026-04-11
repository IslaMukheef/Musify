namespace Musify.ViewModels;

using Musify.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
public class NewPlayListViewModel  : INotifyPropertyChanged
{
    public ObservableCollection<PlayList> playlist { get; set; }
    private ImageSource _playListImagel;
    private string _title;
    private int _playlistId;
    private string _imagePath;

    public int GetNewListId
    {
        get => _playlistId;
        set
        {
            _playlistId = value;    
            
        }
    }

    public string NewTitle
    {
        get =>_title;
        set
        {
            _title = value;
            OnPropertyChanged();
        }
    }
    public ImageSource PlayListImage
    {
        get => _playListImagel;
        set
        {
            _playListImagel = value;
            OnPropertyChanged();
        }
    }
	public NewPlayListViewModel()
	{
        playlist = new ObservableCollection<PlayList>();
    }

    // https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device-media/picker?view=net-maui-10.0&tabs=android
    public async Task PickPhotoAsync()
    {
		FileResult result = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
        {
            Title = "Select your photo"
        });

        if(result!= null)
        {
            _imagePath = result.FullPath;
            PlayListImage = ImageSource.FromFile(_imagePath);
        }
        else
        {
            // if user did not chose a picture use defualt picture
            _imagePath = "dotnet_bot.png";
            PlayListImage = ImageSource.FromFile(_imagePath);
        }
    }

    public async Task OnCreateNewPlaylist()
    {
        // set new id for the playlist making sure each playlist get a new id
        GetNewListId = playlist.Any() ? playlist.Max(p => p.PlayListID) + 1 : 1;
        playlist.Add(new PlayList(NewTitle, GetNewListId, _imagePath, "Isla"));
            
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}