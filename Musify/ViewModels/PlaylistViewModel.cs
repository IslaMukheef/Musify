using Musify.Models;
using System.Security.Cryptography.X509Certificates;

namespace Musify.ViewModels;

public class PlaylistViewModel : ContentPage
{
	public PlayList _currentPlalist;
	public PlaylistViewModel(PlayList playlist)
	{
        _currentPlalist = playlist; 
	}
}