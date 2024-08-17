
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform;
using System.Text.Json.Serialization;


namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //Console.WriteLine($"Connection String: {connectionString}");
            //builder.Services.AddDbContext<TunifyDbContext>(options => options.UseSqlServer(connectionString));

            //builder.Services.AddControllers();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                });

            string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

            builder.Services.AddDbContext<TunifyDbContext>(optionsX => optionsX.UseSqlServer(ConnectionString));


            builder.Services.AddScoped<IUserRepository, UserService>();
            builder.Services.AddScoped<ISongRepository, SongService>();
            builder.Services.AddScoped<IPlaylistRepository, PlaylistService>();
            builder.Services.AddScoped<IArtistRepository, ArtistService>();

            var app = builder.Build();

            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
            app.Run();
        }

    }
}
