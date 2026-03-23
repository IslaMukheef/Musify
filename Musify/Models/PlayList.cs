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
        public string PlayListImage { get; set; }

        public PlayList(string playlistName, int playlistID,string playListImage)
        {
            PlayListName = playlistName;
            PlayListID = playlistID;
            PlayListImage = playListImage;

        }
    }
}
