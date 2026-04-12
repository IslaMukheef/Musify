using Musify.Models;
using Musify.DataAccess;

namespace Musify;

public partial class App : Application
{
    // Single source of truth for the whole app
    public static LibraryData SharedLibrary { get; private set; } = new();

    public App()
    {
        InitializeComponent();

        // Load Jose's seeded data into the shared instance immediately
        var manager = new SeedDataManager();
        SharedLibrary = manager.ReadSeedData();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}