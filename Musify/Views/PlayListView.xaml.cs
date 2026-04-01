namespace Musify.Views;

using Musify.Models;
using Musify.ViewModels;

public partial class PlayListView : ContentPage
{
	public PlayListView(PlayList selectedPlaylist)
	{
		InitializeComponent();
		BindingContext = new PlaylistViewModel(selectedPlaylist);
	}
}