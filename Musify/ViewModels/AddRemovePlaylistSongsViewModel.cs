using Musify.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Musify.ViewModels;

public class AddRemovePlaylistSongsViewModel : INotifyPropertyChanged
{
    
    private PlayList _selectedPlaylist;
	private Song _selectedSong;


    public string SelectedListImage =>
    string.IsNullOrEmpty(CurrentPlayList?.PlayListImage)
        ? "dotnet_bot.png"
        : CurrentPlayList.PlayListImage;
    public Song SelectedSong
    {
        get => _selectedSong;
        set
        {
            _selectedSong = value;
            OnPropertyChanged();

        }
    }
    public PlayList CurrentPlayList
    {
        get => _selectedPlaylist;
        set
        {
            _selectedPlaylist = value;
            OnPropertyChanged();

        }
    }
    public AddRemovePlaylistSongsViewModel(PlayList selectedList)
	{
        CurrentPlayList = selectedList;
	}

	public async Task OnDeleteButtonClicked()
	{
		if(SelectedSong != null)
        {
            CurrentPlayList.Songs.Remove(SelectedSong);
            OnPropertyChanged();
        }
	}
    public IReadOnlyCollection<Song> PlayListSongs
    {
        get => CurrentPlayList.Songs;
    }
    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}