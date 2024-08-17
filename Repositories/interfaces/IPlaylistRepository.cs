using Tunify_Platform.Models;

namespace Tunify_Platform
{
    public interface IPlaylistRepository
    {
        Task<Playlist> CreatePlaylist(Playlist playlist);
        Task<List<Playlist>> GetAllPlaylist();
        Task<Playlist> GetPlaylistById(int id);
        Task<Playlist> UpdatePlaylistById(int id, Playlist playlist);
        Task DeletePlaylist(int id);
        Task AddSongToPlaylistAsync(int playlistId, int songId);
        Task<IEnumerable<Song>> GetSongsInPlaylistAsync(int playlistId);
    }
}