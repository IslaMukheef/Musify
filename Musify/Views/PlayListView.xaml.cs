namespace Musify.Views;

using Musify.Models;
using Musify.ViewModels;
using System.Diagnostics;

public partial class PlayListView : ContentPage
{
	public PlayListView(PlayList selectedPlaylist)
	{
		InitializeComponent();
		BindingContext = new PlaylistViewModel(selectedPlaylist);
        Debug.WriteLine(selectedPlaylist?.PlayListName);
    }

    
    private async void OnViewSongTapped(object sender, TappedEventArgs args)
    {
        //if (BindingContext is LibraryViewModel libraryView)
        //    await Navigation.PushAsync(new PlayListView(libraryView.SelectedPlaylist));
    }

    private async void OnProfileTapped(object sender, TappedEventArgs args)
    {
        //if (BindingContext is LibraryViewModel libraryView)
        //    await Navigation.PushAsync(new PlayListView(libraryView.SelectedPlaylist));
    }
}