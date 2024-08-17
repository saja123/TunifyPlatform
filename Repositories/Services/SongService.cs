using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;
using Tunify_Platform;

namespace Tunify_Platform
{
    public class SongService : ISongRepository
    {
        private readonly TunifyDbContext _context;

        public SongService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Song> CreateSong(Song song)
        {
            _context.Song.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<Song> DeleteSongById(int id)
        {
            var deletesong = await GetSongById(id);
            if (deletesong != null)
            {
                _context.Song.Remove(deletesong);
                await _context.SaveChangesAsync();
            }
            return deletesong;
        }

        public async Task<List<Song>> GetAllSong()
        {
            var allsong = await _context.Song.ToListAsync();
            return allsong;
        }

        public async Task<Song> GetSongById(int id)
        {
            var allsongs = await _context.Song.FindAsync(id);
            return allsongs;
        }

        public async Task<Song> UpdateSongById(int id, Song updatedSong)
        {
            var existingSong = await _context.Song.FindAsync(id);
            if (existingSong != null)
            {
                existingSong.Title = updatedSong.Title;
                existingSong.ArtistId = updatedSong.ArtistId;
                existingSong.AlbumId = updatedSong.AlbumId;
                existingSong.Duration = updatedSong.Duration;
                existingSong.Genre = updatedSong.Genre;
                existingSong.Artist = updatedSong.Artist;
                existingSong.Album = updatedSong.Album;
                existingSong.PlaylistSongs = updatedSong.PlaylistSongs;

                await _context.SaveChangesAsync();
            }
            return existingSong;
        }


        async Task ISongRepository.DeleteSongById(int id)
        {
            var deletesong = await GetSongById(id);
            _context.Song.Remove(deletesong);
            await _context.SaveChangesAsync();
        }
    }
}