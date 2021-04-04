using Malcaba.MovieCollector.Data.Models;
using Malcaba.MovieCollector.Data.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Malcaba.MovieCollector.Automation
{
    public static class DatabaseMigrator
    {
        public static async Task RunUpdate()
        {
            var options = new DbContextOptionsBuilder<MovieDbContext>()
                .UseSqlite(ConnectionString)
                .Options;

            using var context = new MovieDbContext(options);
            await context.Database.EnsureDeletedAsync();

            await context.Database.MigrateAsync();

            var movieService = new MovieService(context);

            await movieService.GetFilesAsync();
        }

        private static string ConnectionString => new SqliteConnectionStringBuilder
        {
            DataSource = "Movies.db"
        }.ToString();
    }
}
