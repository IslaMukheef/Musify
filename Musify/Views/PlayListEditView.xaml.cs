namespace Musify.Views;

using Musify.Models;
using ViewModels;
public partial class PlayListEditView : ContentPage
{
	public PlayListEditView(LibraryData _lib)
	{
		InitializeComponent();
		BindingContext = new PlayListEditViewModel(_lib);
	}

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is PlayListEditViewModel vm)
            await vm.OnDeleteButtonClicked();
        //pop back to libray after creating the new playlist
        //await Navigation.PopAsync();
    }

private async void OnBackButtonClicked(object sender, EventArgs e)
    {
       
        await Navigation.PopAsync();
    }
}