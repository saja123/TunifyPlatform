using Tunify_Platform.Models;

namespace Tunify_Platform
{
    public interface ISongRepository
    {
        Task<Song> createSong(Song song);
        Task<List<Song>> GetAllSong();
        Task<Song> GetSongById(int id);
        Task<Song> UpdateSongById(int id, Song song);
        Task DeleteSongById(int id);

    }
}
