using System;

namespace Musify.Models
{
    public class Song
    {
        public Guid SongId { get; set; }
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public string ArtworkUrl { get; set; }
        public string LocalPath { get; set; }
        public string PreviewUrl { get; set; }
        public int DurationMs { get; set; }

        public Song(string title, string artistName, string albumName, string artworkUrl, string localPath, string previewUrl, int durationMs)
        {
            SongId = Guid.NewGuid();
            Title = title;
            ArtistName = artistName;
            AlbumName = albumName;
            ArtworkUrl = artworkUrl;
            LocalPath = localPath;
            PreviewUrl = previewUrl;
            DurationMs = durationMs;
        }
    }
}
