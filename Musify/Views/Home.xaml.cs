using Musify.Models;
using Musify.Services;

namespace Musify.Views;

public partial class Home : ContentPage
{
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
            FirstPlaylistImage.Source = data.PlayLists[0].PlayListImage;
            FirstPlaylistTitle.Text = data.PlayLists[0].PlayListName;
            FirstPlaylistSubtitle.Text = data.PlayLists[0].CreatorName;
        }

        if (data.PlayLists.Count > 1)
        {
            SecondPlaylistImage.Source = data.PlayLists[1].PlayListImage;
            SecondPlaylistTitle.Text = data.PlayLists[1].PlayListName;
            SecondPlaylistSubtitle.Text = data.PlayLists[1].CreatorName;
        }
    }

    private void LoadSongSection(LibraryData data)
    {
        if (data.Songs.Count > 0)
        {
            FirstSongImage.Source = data.Songs[0].SongImage;
            FirstSongTitle.Text = data.Songs[0].Title;
            FirstSongSubtitle.Text = data.Songs[0].ArtistName;
        }

        if (data.Songs.Count > 4)
        {
            SecondSongImage.Source = data.Songs[4].SongImage;
            SecondSongTitle.Text = data.Songs[4].Title;
            SecondSongSubtitle.Text = data.Songs[4].ArtistName;
        }

        if (data.Songs.Count > 8)
        {
            ThirdSongImage.Source = data.Songs[8].SongImage;
            ThirdSongTitle.Text = data.Songs[8].Title;
            ThirdSongSubtitle.Text = data.Songs[8].ArtistName;
        }

        if (data.Songs.Count > 10)
        {
            FourthSongImage.Source = data.Songs[10].SongImage;
            FourthSongTitle.Text = data.Songs[10].Title;
            FourthSongSubtitle.Text = data.Songs[10].ArtistName;
        }
    }

    private async void OnHomeSearchBarFocused(object? sender, FocusEventArgs e)
    {
        await Navigation.PushAsync(new Search());
    }
}
