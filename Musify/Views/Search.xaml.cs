namespace Musify.Views;

public partial class Search : ContentPage
{
    public Search()
    {
        InitializeComponent();
    }

    private void OnPageLoaded(object? sender, EventArgs e)
    {
        UpdateSearchLabel();
        SearchInputBar.Focus();
    }

    private async void OnCancelButtonClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void UpdateSearchLabel()
    {
        bool hasQuery = !string.IsNullOrWhiteSpace(SearchInputBar.Text);

        SearchSectionLabel.Text = "Explore";
        SearchSectionLabel.IsVisible = !hasQuery;
        SuggestionList.IsVisible = !hasQuery;
        ResultsList.IsVisible = hasQuery;
    }

    private void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
    {
        UpdateSearchLabel();
    }

    private void OnSuggestionClicked(object? sender, EventArgs e)
    {
        if (sender is not Button button)
        {
            return;
        }

        SearchInputBar.Text = button.Text;
    }
}
