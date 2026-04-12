using Musify.Models;
using Musify.Services;
using Musify.ViewModels;

namespace Musify.Views;

public partial class Search : ContentPage
{
    private SearchViewModel ViewModel => (SearchViewModel)BindingContext;

    public Search()
    {
        InitializeComponent();
    }

    private void OnPageLoaded(object? sender, EventArgs e)
    {
        SearchInputBar.Focus();
    }

    private async void OnCancelButtonClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
    {
        ViewModel.UpdateFilteredSongs();
    }

    private void OnSuggestionClicked(object? sender, EventArgs e)
    {
        if (sender is not Button button)
        {
            return;
        }

        SearchInputBar.Text = button.Text;
    }

    private async void OnResultTapped(object? sender, TappedEventArgs e)
    {
        if (sender is not Border tappedBorder || tappedBorder.BindingContext is not Song selectedSong)
        {
            return;
        }

        MediaService.Play(selectedSong);
        await Navigation.PushAsync(new SongPlayerView(selectedSong));
    }
}
