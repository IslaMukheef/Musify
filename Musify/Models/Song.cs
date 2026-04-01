using System;

namespace Musify.Models
{

    
    public class Song
    {
        //ISLA: We need to add song image so I added this but you can change it to something else but Please keep the getter and setter as SongImage
        private string _songImage;
        public Guid SongId { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public string ArtworkUrl { get; set; }
        public string LocalPath { get; set; }
        public string PreviewUrl { get; set; }
        public int DurationMs { get; set; }
        public string SongImage
        {
            get => _songImage;
            set
            {
                if (string.IsNullOrEmpty(value))
                    _songImage = "dotnet_bot.png";
                _songImage = value;
            }
        }

        public Song(string title, string artistName, string albumName, string artworkUrl, string localPath, string previewUrl, int durationMs, string songImage)
        {
            SongId = Guid.NewGuid();
            Title = title;
            ArtistName = artistName;
            AlbumName = albumName;
            ArtworkUrl = artworkUrl;
            LocalPath = localPath;
            PreviewUrl = previewUrl;
            DurationMs = durationMs;
            SongImage = songImage;
        }
    }
}
