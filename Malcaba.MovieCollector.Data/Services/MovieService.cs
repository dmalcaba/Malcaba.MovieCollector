using Malcaba.MovieCollector.Data.Dto;
using Malcaba.MovieCollector.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Malcaba.MovieCollector.Data.Services
{
    public class MovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        public async Task GetFilesAsync()
        {
            var path = $@"..\..\..\..\Malcaba.MovieCollector.Data\Json\";

            var fileList = Directory.GetFiles(path);

            foreach (var file in fileList)
            {
                var jsonString = await File.ReadAllTextAsync(file, Encoding.UTF8);
                var movie = FileToObject(jsonString);

                await SaveMovieAsync(movie);
            }
        }

        public MovieDto FileToObject(string jsonString)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new DateTimeConverter());

            var movie = JsonSerializer.Deserialize<MovieDto>(jsonString, options);

            return movie;
        }

        public async Task SaveMovieAsync(MovieDto movie)
        {
            var rateId = await SaveRatingAsync(movie.Rated);
            var formatId = await GetFormatId("Blu-ray");

            var movieToSave = new Movie 
            { 
                Genre = movie.Genre,
                Plot = movie.Plot,
                Released = movie.Released,
                RunTime = movie.RuntimeInMinutes,
                RateId = rateId,
                FormatId = formatId,
                Title = movie.Title,
                TitleSort = DetermineSortTitle(movie.Title),
                Actors = movie.Actors,
                Director = movie.Director,
                ImdbID = movie.ImdbID,
                Poster = movie.Poster
            };

            _context.Movie.Add(movieToSave);
            await _context.SaveChangesAsync();
        }

        public string DetermineSortTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                return string.Empty;

            if (title.StartsWith("The "))
            {
                var sortTitle = title[4..] + ", The";
                return sortTitle;
            }

            if (title.StartsWith("A "))
            {
                var sortTitle = title[2..] + ", A";
                return sortTitle;
            }

            return title;
        }


        public async Task<int> GetFormatId(string format)
        {
            var formatExists = await _context.Format.FirstOrDefaultAsync(x => x.Name == format);
            if (formatExists != null) return formatExists.Id;

            var formatToSave = new Format
            {
                Name = format
            };
            _context.Format.Add(formatToSave);
            await _context.SaveChangesAsync();

            return formatToSave.Id;
        }

        public async Task<int> SaveRatingAsync(string rating)
        {
            var ratingExists = await _context.Rate.FirstOrDefaultAsync(x => x.Name == rating);

            if (ratingExists != null) return ratingExists.Id;

            var ratingToSave = new Rate
            {
                Name = rating
            };

            _context.Rate.Add(ratingToSave);
            await _context.SaveChangesAsync();

            return ratingToSave.Id;
        }
    }
}
