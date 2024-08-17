using Microsoft.EntityFrameworkCore;
using Tunify_Platform;
using Tunify_Platform.Models;

namespace Tunify_Platform
{
    public class ArtistService : IArtistRepository
    {
        private readonly TunifyDbContext _context;

        public ArtistService(TunifyDbContext context)
        {
            _context = context;
        }

        public async Task AddSongToArtistAsync(int artistId, int songId)
        {
            var artist = await _context.Artist.Include(a => a.Songs).FirstOrDefaultAsync(a => a.ArtistId == artistId);
            if (artist == null)
            {
                throw new Exception("Artist not found");
            }

            var song = await _context.Song.FindAsync(songId);
            if (song == null)
            {
                throw new Exception("Song not found");
            }

            artist.Songs.Add(song);
            await _context.SaveChangesAsync();
        }

        public async Task<Artist> createArtist(Artist artist)
        {
            _context.Artist.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task DeleteArtistById(int id)
        {
            var deletartist = await GetArtistById(id);
            _context.Artist.Remove(deletartist);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Artist>> GetAllArtist()
        {
            var allartist = await _context.Artist.ToListAsync();
            return allartist;
        }

        public async Task<Artist> GetArtistById(int id)
        {
            var allartist = await _context.Artist.FindAsync(id);
            return allartist;
        }

        public async Task<IEnumerable<Song>> GetSongsByArtistAsync(int artistId)
        {
            var artist = await _context.Artist.Include(a => a.Songs).FirstOrDefaultAsync(a => a.ArtistId == artistId);
            if (artist == null)
            {
                throw new Exception("Artist not found");
            }

            return artist.Songs;
        }

        public async Task<Artist> UpdateArtistById(int id, Artist updatedArtist)
        {
            //var axitingplaylist = await _context.Playlist.FindAsync(id); // make replace for the information
            //axitingplaylist = playlist;
            //await _context.SaveChangesAsync();
            //return axitingplaylist;
            var existingArtist = await _context.Artist.FindAsync(id);
            if (existingArtist != null)
            {
                existingArtist.Name = updatedArtist.Name;//make update just not make replace 
                existingArtist.Bio = updatedArtist.Bio;
                existingArtist.Songs = updatedArtist.Songs;
                existingArtist.Albums = updatedArtist.Albums;

                await _context.SaveChangesAsync();
            }
            return existingArtist;
        }

    }
}