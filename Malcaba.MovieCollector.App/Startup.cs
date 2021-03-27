using Malcaba.MovieCollector.Data.Models;
using Malcaba.MovieCollector.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Malcaba.MovieCollector.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var sqliteConnString = GetSqliteConnection("Movies.db");

            services.AddControllersWithViews();
            services.AddDbContext<MovieDbContext>(options => options.UseSqlite(sqliteConnString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/connection-strings
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        private string GetSqliteConnection(string dataSource) 
            => new SqliteConnectionStringBuilder
                {
                    DataSource = dataSource
                }.ToString();
    }
}
