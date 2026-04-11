using Musify.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Musify.ViewModels;

public class PlayListEditViewModel : INotifyPropertyChanged
{
    private LibraryData _library;
    private PlayList _selectedPlaylist;
    public ObservableCollection<PlayList> playlist => _library.PlayLists;

    public PlayList SelectedPlaylist
    {
        get => _selectedPlaylist;
        set
        {
            _selectedPlaylist = value;
            OnPropertyChanged();

        }
    }
    public PlayListEditViewModel(LibraryData library)
	{
		_library = library;
	}

    public async Task OnDeleteButtonClicked()
    {
        if(SelectedPlaylist != null)
        {
            _library.PlayLists.Remove(SelectedPlaylist);
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string name = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}