using Musify.ViewModels;
using Musify.Models;

namespace Musify.Views;

public partial class AddRemovePlaylistSongsView : ContentPage
{
	public AddRemovePlaylistSongsView(PlayList currentList)
	{
		InitializeComponent();
        BindingContext = new AddRemovePlaylistSongsViewModel(currentList);

    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is AddRemovePlaylistSongsViewModel vm)
            await vm.OnDeleteButtonClicked();
        //pop back to libray after creating the new playlist
        //await Navigation.PopAsync();
    }
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {

        await Navigation.PopAsync();
    }
}