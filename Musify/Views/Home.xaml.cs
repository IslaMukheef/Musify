using Musify.Models;
using Musify.Services;

namespace Musify.Views;

public partial class Home : ContentPage
{
    private PlayList? _firstPlaylist;
    private PlayList? _secondPlaylist;
    private Song? _firstSong;
    private Song? _secondSong;
    private Song? _thirdSong;
    private Song? _fourthSong;

    public Home()
    {
        InitializeComponent();

        // Connects global service to the element on this page
        MediaService.Initialize(GlobalMediaElement);
        LoadHomeSections();
    }

    private void LoadHomeSections()
    {
        LibraryData data = App.SharedLibrary;
        LoadExploreSection(data);
        LoadSongSection(data);
    }

    private void LoadExploreSection(LibraryData data)
    {
        if (data.PlayLists.Count > 0)
        {
            _firstPlaylist = data.PlayLists[0];
            SetPlaylistCard(FirstPlaylistImage, FirstPlaylistTitle, FirstPlaylistSubtitle, _firstPlaylist);
        }

        if (data.PlayLists.Count > 1)
        {
            _secondPlaylist = data.PlayLists[1];
            SetPlaylistCard(SecondPlaylistImage, SecondPlaylistTitle, SecondPlaylistSubtitle, _secondPlaylist);
        }
    }

    private void LoadSongSection(LibraryData data)
    {
        if (data.Songs.Count > 0)
        {
            _firstSong = data.Songs[0];
            SetSongCard(FirstSongImage, FirstSongTitle, FirstSongSubtitle, _firstSong);
        }

        if (data.Songs.Count > 4)
        {
            _secondSong = data.Songs[4];
            SetSongCard(SecondSongImage, SecondSongTitle, SecondSongSubtitle, _secondSong);
        }

        if (data.Songs.Count > 8)
        {
            _thirdSong = data.Songs[8];
            SetSongCard(ThirdSongImage, ThirdSongTitle, ThirdSongSubtitle, _thirdSong);
        }

        if (data.Songs.Count > 10)
        {
            _fourthSong = data.Songs[10];
            SetSongCard(FourthSongImage, FourthSongTitle, FourthSongSubtitle, _fourthSong);
        }
    }

    private void SetPlaylistCard(Image image, Label title, Label subtitle, PlayList playlist)
    {
        image.Source = playlist.PlayListImage;
        title.Text = playlist.PlayListName;
        subtitle.Text = playlist.CreatorName;
    }

    private void SetSongCard(Image image, Label title, Label subtitle, Song song)
    {
        image.Source = song.SongImage;
        title.Text = song.Title;
        subtitle.Text = song.ArtistName;
    }

    private async void OnHomeSearchBarFocused(object? sender, FocusEventArgs e)
    {
        await Navigation.PushAsync(new Search());
    }

    private async void OnFirstPlaylistTapped(object? sender, TappedEventArgs e)
    {
        await OpenPlaylistAsync(_firstPlaylist);
    }

    private async void OnSecondPlaylistTapped(object? sender, TappedEventArgs e)
    {
        await OpenPlaylistAsync(_secondPlaylist);
    }

    private async void OnFirstSongTapped(object? sender, TappedEventArgs e)
    {
        await OpenSongAsync(_firstSong);
    }

    private async void OnSecondSongTapped(object? sender, TappedEventArgs e)
    {
        await OpenSongAsync(_secondSong);
    }

    private async void OnThirdSongTapped(object? sender, TappedEventArgs e)
    {
        await OpenSongAsync(_thirdSong);
    }

    private async void OnFourthSongTapped(object? sender, TappedEventArgs e)
    {
        await OpenSongAsync(_fourthSong);
    }

    private async Task OpenPlaylistAsync(PlayList? playlist)
    {
        if (playlist == null)
        {
            return;
        }

        await Navigation.PushAsync(new PlayListView(playlist));
    }

    private async Task OpenSongAsync(Song? song)
    {
        if (song == null)
        {
            return;
        }

        MediaService.Play(song);
        await Navigation.PushAsync(new SongPlayerView(song));
    }
}
