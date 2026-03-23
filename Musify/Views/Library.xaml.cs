using Musify.ViewModels;

namespace Musify.Views;

public partial class Library : ContentPage
{
	public Library()
	{
        InitializeComponent();
        BindingContext = new LibraryViewModel();

    }

    async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    
}