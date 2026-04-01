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
}