using System.Collections.ObjectModel;
using Musify.DataAccess;
using Musify.Models;
using Musify.Services;

namespace Musify.Views;

public partial class Search : ContentPage
{
    private readonly List<Song> _allSongs;
    private readonly ObservableCollection<Song> _filteredSongs;

    public Search()
    {
        InitializeComponent();

        SeedDataManager manager = new SeedDataManager();
        LibraryData data = manager.ReadSeedData();
        _allSongs = new List<Song>(data.Songs);
        _filteredSongs = new ObservableCollection<Song>();

        BindableLayout.SetItemsSource(ResultsList, _filteredSongs);
    }

    private void OnPageLoaded(object? sender, EventArgs e)
    {
        UpdateSearchLabel();
        SearchInputBar.Focus();
    }

    private async void OnCancelButtonClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void UpdateSearchLabel()
    {
        bool hasQuery = !string.IsNullOrWhiteSpace(SearchInputBar.Text);
        bool hasResults = _filteredSongs.Count > 0;

        SearchSectionLabel.Text = "Suggestions";
        SearchSectionLabel.IsVisible = !hasQuery;
        SuggestionList.IsVisible = !hasQuery;
        ResultsList.IsVisible = hasQuery && hasResults;
        NoResultsLabel.IsVisible = hasQuery && !hasResults;
    }

    private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
    {
        UpdateFilteredSongs();
        UpdateSearchLabel();
    }

    private void OnSuggestionClicked(object? sender, EventArgs e)
    {
        if (sender is not Button button)
        {
            return;
        }

        SearchInputBar.Text = button.Text;
    }

    private async void OnResultTapped(object? sender, TappedEventArgs e)
    {
        if (sender is not Border tappedBorder || tappedBorder.BindingContext is not Song selectedSong)
        {
            return;
        }

        MediaService.Play(selectedSong);
        await Navigation.PushAsync(new SongPlayerView(selectedSong));
    }

    private void UpdateFilteredSongs()
    {
        string searchText = SearchInputBar.Text?.Trim() ?? string.Empty;

        _filteredSongs.Clear();

        if (searchText == string.Empty)
        {
            return;
        }

        foreach (Song song in _allSongs)
        {
            bool matchesTitle = song.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase);
            bool matchesArtist = song.ArtistName.Contains(searchText, StringComparison.OrdinalIgnoreCase);
            bool matchesAlbum = song.AlbumName.Contains(searchText, StringComparison.OrdinalIgnoreCase);

            if (matchesTitle || matchesArtist || matchesAlbum)
            {
                _filteredSongs.Add(song);
            }
        }
    }
}
