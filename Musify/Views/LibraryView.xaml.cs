using Musify.ViewModels;
using Musify.Models;
using Musify.Services;

namespace Musify.Views;

public partial class LibraryView : ContentPage
{
    public LibraryView()
    {
        InitializeComponent();
        BindingContext = new LibraryViewModel();
    }

    // trigger when user clicks on an uploaded song
    private void OnSongTapped(object sender, TappedEventArgs e)
    {
        if (sender is Grid tappedGrid && tappedGrid.BindingContext is Song selectedSong)
        {
            MediaService.Play(selectedSong);
        }
    }

    // trigger when user clicks on a playlist
    private async void OnViewPlayListTapped(object sender, TappedEventArgs args)
    {
        if(BindingContext is LibraryViewModel libraryView)
            await Navigation.PushAsync(new PlayListView(libraryView.SelectedPlaylist));
    }

    // to add new playlist
    private async void OnNewClicked(object sender, EventArgs args)
    {
        if (BindingContext is LibraryViewModel libraryView)
            await Navigation.PushAsync(new NewPlayListView(libraryView._library));
    }

    // this will only edit playlist as ADD OR REMOVE SONGS FROM A PLAYLIST
    private async void OnPlayListEditClicked(object sender, EventArgs args)
    {
        if (BindingContext is LibraryViewModel libraryView)
            await Navigation.PushAsync(new PlayListEditView(libraryView._library));
    }

    // this will only allow user to delete a playlist that was created before(by them only if not then it will be unliked)
    private async void OnLibraryEditTapped(object sender, TappedEventArgs args)
    {
        //    if (BindingContext is LibraryViewModel libraryView)
        //        await Navigation.PushAsync(new PlayListEditView());
    }
}