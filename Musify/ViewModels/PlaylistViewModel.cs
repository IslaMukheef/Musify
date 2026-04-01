using Musify.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Musify.ViewModels;

public class PlaylistViewModel : INotifyPropertyChanged
{
	private PlayList _currentPlalist;
	private string _selectedListImage;
    private Song _selectedSong;

    public Song newSong { get; set; }

    public Song SelectedSong
	{
		get => _selectedSong;
		set
		{
			if(value is null) 
				throw new ArgumentNullException(nameof(value));
			_selectedSong = value;
		}
	}

    public PlayList CurrentPlayList
	{
		get=>_currentPlalist;
		set
		{
			if (value == null) 
				throw new ArgumentNullException("PlayList Dose not exist?!!");
			_currentPlalist = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectedListImage));
        }
	}
	// if the value of Playlist image is null use the dotnet_bot image else use the image the user did upload
    public string SelectedListImage =>
    string.IsNullOrEmpty(CurrentPlayList?.PlayListImage)
        ? "dotnet_bot.png"
        : CurrentPlayList.PlayListImage;
    public PlaylistViewModel(PlayList playlist)
	{
        CurrentPlayList = playlist;

		newSong = new Song("Good Luck babe", "Chappell Roan", "Midwest", "null", "null", "null", 3, "dotnet_bot.png");
		CurrentPlayList.AddSongToPlaylist(newSong);
        newSong = new Song("Good Luck babe", "Chappell Roan", "Midwest", "null", "null", "null", 3, "dotnet_bot.png");
        CurrentPlayList.AddSongToPlaylist(newSong);
        newSong = new Song("Good Luck babe", "Chappell Roan", "Midwest", "null", "null", "null", 3, "dotnet_bot.png");
        CurrentPlayList.AddSongToPlaylist(newSong);
        newSong = new Song("Good Luck babe", "Chappell Roan", "Midwest", "null", "null", "null", 3, "dotnet_bot.png");
        CurrentPlayList.AddSongToPlaylist(newSong);

    }

	// this will display all the songs from to PlaylistView Model
	public IReadOnlyCollection<Song> PlayListSongs
	{
		get=> _currentPlalist.Songs;
	}
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


}