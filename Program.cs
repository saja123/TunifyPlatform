using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;

namespace YourNamespace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<TunifyDbContext>(options => options.UseSqlServer(connectionString));
            var app = builder.Build();
            app.MapGet("/", () => "Hello World!");
            app.Run();
        }
    }
}
