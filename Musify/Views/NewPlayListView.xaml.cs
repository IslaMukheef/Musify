namespace Musify.Views;

using Musify.Models;
using Musify.ViewModels;

public partial class NewPlayListView 
{
	public NewPlayListView(LibraryData _lib)
	{
		InitializeComponent();
		BindingContext = new NewPlayListViewModel(_lib);
	}


    private async void OnPickPhotoClicked(object sender, EventArgs e)
    {
        if (BindingContext is NewPlayListViewModel vm)
            await vm.PickPhotoAsync();
    }
    private async void OnCreateNewPlaylist(object sender, EventArgs e)
    {
        if (BindingContext is NewPlayListViewModel vm)
            await vm.OnCreateNewPlaylist();
        await Navigation.PopAsync();
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void ShowTheNewPlaylist()
    {
        //do nothing
    }
}