using System.ComponentModel.DataAnnotations.Schema;

namespace Tunify_Platform.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int AlbumId { get; set; }
        public TimeSpan Duration { get; set; }
        public string Genre { get; set; }

        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}