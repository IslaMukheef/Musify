using Musify.DataAccess;
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
        private LibraryData _library;
        public ObservableCollection<PlayList> playlist => _library.PlayLists;

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
            _library = new LibraryData();
            LoadData();





        }

        private async void LoadData()
        {
            var manager = new SeedDataManager();
            _library = await manager.ReadSeedDataAsync();

            OnPropertyChanged(nameof(playlist));
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
