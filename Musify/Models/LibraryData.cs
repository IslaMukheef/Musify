using System.Collections.ObjectModel;

namespace Musify.Models
{
    public class LibraryData
    {
        public ObservableCollection<Song> Songs { get; set; }
        public ObservableCollection<PlayList> PlayLists { get; set; }

        public LibraryData()
        {
            Songs = new ObservableCollection<Song>();
            PlayLists = new ObservableCollection<PlayList>();
        }
    }
}
