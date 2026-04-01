using Musify.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Musify.ViewModels
{
    public class LibraryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PlayList> playlist { get; set; }
        private PlayList _selectedPlaylist;

        public PlayList SelectedPlaylist
        {
            get=> _selectedPlaylist;
            set
            {
                _selectedPlaylist = value;
                OnPropertyChanged();

            }
        }

        public LibraryViewModel()
        {
            playlist = new ObservableCollection<PlayList>
        {
            new PlayList("Chill Vibes", 1,"dotnet_bot.png","Isla"),
            new PlayList("Workout Mix", 2,"dotnet_bot.png"," Chappell Roan")
        };
        }

        


        //https://stackoverflow.com/questions/17885923/onpropertychange-does-not-exist-in-the-current-context
        // needed to get the current selected playlist to pass it to the other ViewModels
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
