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
        public string CreatorName { get; set; }
        public ObservableCollection<Song> Songs { get; set; }

        public PlayList(string playlistName, int playlistID,string playListImage, string creatorName)
        {
            PlayListName = playlistName;
            PlayListID = playlistID;
            PlayListImage = playListImage;
            Songs = new ObservableCollection<Song>();
            CreatorName = creatorName;
        }

        
        public void AddSongToPlaylist(Song song)
        {
            Songs.Add(song);
        } 
    }
}
