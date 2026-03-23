using Microsoft.Extensions.DependencyInjection;
using Musify.Models;

namespace Musify;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
    }

	protected override Window CreateWindow(IActivationState? activationState)
	{
        return new Window(new NavigationPage(new MainPage()));
    }
}