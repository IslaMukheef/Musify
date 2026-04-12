using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Musify.Models;

namespace Musify.ViewModels;

public class SearchViewModel : INotifyPropertyChanged
{
    private string _searchText = string.Empty;
    private bool _showSuggestions = true;
    private bool _showResults;
    private bool _showNoResults;

    public ObservableCollection<Song> FilteredSongs { get; set; }

    public string SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            OnPropertyChanged();
        }
    }

    public bool ShowSuggestions
    {
        get => _showSuggestions;
        set
        {
            _showSuggestions = value;
            OnPropertyChanged();
        }
    }

    public bool ShowResults
    {
        get => _showResults;
        set
        {
            _showResults = value;
            OnPropertyChanged();
        }
    }

    public bool ShowNoResults
    {
        get => _showNoResults;
        set
        {
            _showNoResults = value;
            OnPropertyChanged();
        }
    }

    public SearchViewModel()
    {
        FilteredSongs = new ObservableCollection<Song>();
    }

    public void UpdateFilteredSongs()
    {
        string searchText = SearchText.Trim();

        FilteredSongs.Clear();

        if (searchText == string.Empty)
        {
            ShowSuggestions = true;
            ShowResults = false;
            ShowNoResults = false;
            return;
        }

        foreach (Song song in App.SharedLibrary.Songs)
        {
            bool matchesTitle = song.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase);
            bool matchesArtist = song.ArtistName.Contains(searchText, StringComparison.OrdinalIgnoreCase);
            bool matchesAlbum = song.AlbumName.Contains(searchText, StringComparison.OrdinalIgnoreCase);

            if (matchesTitle || matchesArtist || matchesAlbum)
            {
                FilteredSongs.Add(song);
            }
        }

        ShowSuggestions = false;
        ShowResults = FilteredSongs.Count > 0;
        ShowNoResults = FilteredSongs.Count == 0;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
