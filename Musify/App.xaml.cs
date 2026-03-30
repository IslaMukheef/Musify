using Microsoft.Extensions.DependencyInjection;
using Musify.Models;
using Musify.Views;

namespace Musify;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
    }

	protected override Window CreateWindow(IActivationState? activationState)
	{
        return new Window(new AppShell());
    }
}
