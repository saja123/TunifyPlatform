using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform
{
    public class TunifyDbContext : DbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<PlaylistSong> PlaylistSong { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<User> Users { get; set; }

        public TunifyDbContext(DbContextOptions<TunifyDbContext> options)
            : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
        //        .Build();

        //    var connectionString = config.GetSection("DefaultConnection").Value;

        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region PlaylistSong configuration
            modelBuilder.Entity<PlaylistSong>()
                .HasKey(ps => ps.PlaylistSongId);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Playlist)
                .WithMany(p => p.PlaylistSongs)
                .HasForeignKey(ps => ps.PlaylistId);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId);
            #endregion

            #region Subscription configuration
            modelBuilder.Entity<Subscription>()
                .HasMany(s => s.Users)
                .WithOne(u => u.Subscriptions)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Subscription>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);
            #endregion

            #region User configuration
            modelBuilder.Entity<User>()
                .HasMany(u => u.Playlists)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);
            #endregion

            #region Artist configuration
            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Albums)
                .WithOne(al => al.Artist)
                .HasForeignKey(al => al.ArtistId);

            modelBuilder.Entity<Artist>()
                .HasMany(a => a.Songs)
                .WithOne(s => s.Artist)
                .HasForeignKey(s => s.ArtistId);
            #endregion

            #region Album configuration
            modelBuilder.Entity<Album>()
                .HasMany(al => al.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.AlbumId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Song configuration
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Seed initial data
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "user1", Email = "user1@example.com", JoinDate = DateTime.Now, SubscriptionId = 1 },
                new User { UserId = 2, Username = "user2", Email = "user2@example.com", JoinDate = DateTime.Now, SubscriptionId = 1 }
            );

            modelBuilder.Entity<Subscription>().HasData(
                new Subscription { SubscriptionId = 1, SubscriptionType = "Basic", Price = 9.99m },
                new Subscription { SubscriptionId = 2, SubscriptionType = "Premium", Price = 19.99m }
            );

            modelBuilder.Entity<Song>().HasData(
                new Song { SongId = 1, Title = "Song 1", ArtistId = 1, AlbumId = 1, Duration = new TimeSpan(0, 3, 45), Genre = "Pop" },
                new Song { SongId = 2, Title = "Song 2", ArtistId = 1, AlbumId = 1, Duration = new TimeSpan(0, 4, 20), Genre = "Rock" }
            );

            modelBuilder.Entity<Artist>().HasData(
                new Artist { ArtistId = 1, Name = "Artist 1", Bio = "Bio of Artist 1" }
            );

            modelBuilder.Entity<Album>().HasData(
                new Album { AlbumId = 1, AlbumName = "Album 1", ReleaseDate = DateTime.Now, ArtistId = 1 }
            );

            modelBuilder.Entity<Playlist>().HasData(
                new Playlist { PlaylistId = 1, UserId = 1, PlaylistName = "Playlist 1", CreatedDate = DateTime.Now },
                new Playlist { PlaylistId = 2, UserId = 2, PlaylistName = "Playlist 2", CreatedDate = DateTime.Now }
            );

            modelBuilder.Entity<PlaylistSong>().HasData(
                new PlaylistSong { PlaylistSongId = 1, PlaylistId = 1, SongId = 1 },
                new PlaylistSong { PlaylistSongId = 2, PlaylistId = 1, SongId = 2 },
                new PlaylistSong { PlaylistSongId = 3, PlaylistId = 2, SongId = 1 }
            );
            #endregion
        }


    }
}
