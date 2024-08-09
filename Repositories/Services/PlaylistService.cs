using Microsoft.EntityFrameworkCore;
using Tunify_Platform;
using Tunify_Platform.Models;

namespace Tunify_Platform
{
    public class PlaylistService : IPlaylistRepository
    {
        private readonly TunifyDbContext _context;

        public PlaylistService(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task <Playlist> CreatePlaylist(Playlist playlist)
        {
             _context.Playlist.Add(playlist);
            await _context.SaveChangesAsync();
            return playlist;
            
        }

        public async Task DeletePlaylist(int id)
        {
            var deleteplaylist = await GetPlaylistById(id);
            if (deleteplaylist != null)
            {
                _context.Playlist.Remove(deleteplaylist);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Playlist>> GetAllPlaylist()
        {
            var allplaylist = await _context.Playlist.ToListAsync();
            return allplaylist;
        }

        public async Task<Playlist> GetPlaylistById(int id)
        {
            var allplaylists = await _context.Playlist.FindAsync(id);

            return allplaylists;
        }

        public async Task<Playlist> UpdatePlaylistById(int id, Playlist updatedPlaylist)
        {
            var existingPlaylist = await _context.Playlist.FindAsync(id);
            if (existingPlaylist != null)
            {
                existingPlaylist.UserId = updatedPlaylist.UserId;
                existingPlaylist.PlaylistName = updatedPlaylist.PlaylistName;
                existingPlaylist.CreatedDate = updatedPlaylist.CreatedDate;
                existingPlaylist.User = updatedPlaylist.User;
                existingPlaylist.PlaylistSongs = updatedPlaylist.PlaylistSongs;

                await _context.SaveChangesAsync();
            }
            return existingPlaylist;
        }

    }
}
