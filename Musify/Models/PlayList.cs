using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Musify.Models
{

    public class PlayList
    {
        public int PlayListID { get; set; }
        public string PlayListName { get; set; }
        // this should not be mandatory as the user can set on or the system will set one by defualt
        public string PlayListImage { get; set; }
        // will store either the artist name or the person who created the playlist
        public string CreaterName { get; set; }
        public ObservableCollection<Song> Songs { get; set; }

        public PlayList(string playlistName, int playlistID,string playListImage, string createrName)
        {
            PlayListName = playlistName;
            PlayListID = playlistID;
            PlayListImage = playListImage;
            Songs = new ObservableCollection<Song>();
            CreaterName = createrName;
        }
    }
}
