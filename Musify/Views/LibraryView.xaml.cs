using Musify.ViewModels;
namespace Musify.Views;

public partial class LibraryView : ContentPage
{
	public LibraryView()
	{
        InitializeComponent();
        BindingContext = new LibraryViewModel();

    }

  

    // trigger when user clicks on a playlist
    private async void OnViewPlayListTapped(object sender, TappedEventArgs args)
    {
        if(BindingContext is LibraryViewModel libraryView)
            await Navigation.PushAsync(new PlayListView(libraryView.SelectedPlaylist));
    }

    // to add new playlist
    private async void OnNewTapped(object sender, TappedEventArgs args)
    {
        if (BindingContext is LibraryViewModel libraryView)
            await Navigation.PushAsync(new NewPlayListView());
    }

    // this will only edit playlist as ADD OR REMOVE SONGS FROM A PLAYLIST
    private async void OnPlayListEditTapped(object sender, TappedEventArgs args)
    {
        if (BindingContext is LibraryViewModel libraryView)
            await Navigation.PushAsync(new PlayListEditView());
    }

    // this will only allow user to delete a playlist that was created before(by them only if not then it will be unliked)
    private async void OnLibraryEditTapped(object sender, TappedEventArgs args)
    {
        if (BindingContext is LibraryViewModel libraryView)
            await Navigation.PushAsync(new PlayListEditView());
    }
}