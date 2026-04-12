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
        // --- ORIGINAL LOGIC (Commented out to preserve Isla's setup) ---
        // private LibraryData _library = new LibraryData(); 
        // -------------------------------------------------------------------

        // NEW LOGIC: Pointing to App.SharedLibrary to allow local uploads to sync across all tabs.
        // This ensures that songs added in the 'Local' tab appear here and in Search.
        public LibraryData _library => App.SharedLibrary;

        public ObservableCollection<PlayList> playlist => _library.PlayLists;
        
        // Added this so the LibraryView UI can bind to the global list of uploaded songs.
        public ObservableCollection<Song> Songs => _library.Songs;

        private PlayList? _selectedPlaylist;

        public PlayList? SelectedPlaylist
        {
            get => _selectedPlaylist;
            set
            {
                _selectedPlaylist = value;
                OnPropertyChanged();
            }
        }

        //public LibraryViewModel()
        //{
            // --- ORIGINAL LOGIC (Commented out) ---
            // LoadData(); 
            // --------------------------------------
            
            // Note: Data seeding is now handled in App.xaml.cs to ensure 
            // everyone is using the same instance of the library.
        //}

        // https://stackoverflow.com/questions/17885923/onpropertychange-does-not-exist-in-the-current-context
        // needed to get the current selected playlist to pass it to the other ViewModels
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}