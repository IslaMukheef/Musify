using Musify.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Musify.ViewModels
{
    public class LibraryViewModel
    {
        public ObservableCollection<PlayList> PlayList { get; set; }

        public LibraryViewModel()
        {
            PlayList = new ObservableCollection<PlayList>
        {
            new PlayList("Chill Vibes", 1,"dotnet_bot.png"),
            new PlayList("Workout Mix", 2,"dotnet_bot.png")
        };
        }
    }
}
