using Musify.ViewModels;

namespace Musify.Views;

public partial class LocalView : ContentPage
{
    private LocalViewModel _viewModel;

    public LocalView()
    {
        InitializeComponent();
        _viewModel = new LocalViewModel();
        BindingContext = _viewModel;
    }

    // Files "onclicked" event link to LocalView.xaml
    private async void OnSelectFilesClicked(object sender, EventArgs e)
    {
        // Calls file picker in LocalViewModel
        await _viewModel.PickMusicFiles();
    }
}