using Tunify_Platform.Models;

namespace Tunify_Platform
{
    public interface IArtistRepository
    {
        Task<Artist> createArtist(Artist artist);
        Task<List<Artist>> GetAllArtist();
        Task<Artist> GetArtistById(int id);
        Task<Artist> UpdateArtistById(int id, Artist artist);
        Task DeleteArtistById(int id);
        Task AddSongToArtistAsync(int artistId, int songId);
        Task<IEnumerable<Song>> GetSongsByArtistAsync(int artistId);
    }
}