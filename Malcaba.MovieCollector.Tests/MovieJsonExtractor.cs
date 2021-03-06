using Malcaba.MovieCollector.Data.Services;
using System;
using Xunit;

namespace Malcaba.MovieCollector.Tests
{
    public class MovieJsonExtractor
    {
        [Fact]
        public void TestRead()
        {
            var jsonString = @"{
  ""Title"": ""Baby Driver"",
  ""Year"": ""2017"",
  ""Rated"": ""R"",
  ""Released"": ""28 Jun 2017"",
  ""Runtime"": ""113 min"",
  ""Genre"": ""Action, Crime, Drama, Music, Thriller"",
  ""Director"": ""Edgar Wright"",
  ""Writer"": ""Edgar Wright"",
  ""Actors"": ""Ansel Elgort, Jon Bernthal, Jon Hamm, Eiza Gonz�lez"",
  ""Plot"": ""After being coerced into working for a crime boss, a young getaway driver finds himself taking part in a heist doomed to fail."",
  ""Language"": ""English, American Sign Language"",
  ""Country"": ""UK, USA"",
  ""Awards"": ""Nominated for 3 Oscars. Another 42 wins & 62 nominations."",
  ""Poster"": ""https://m.media-amazon.com/images/M/MV5BMjM3MjQ1MzkxNl5BMl5BanBnXkFtZTgwODk1ODgyMjI@._V1_SX300.jpg"",
  ""Ratings"": [
    {
      ""Source"": ""Internet Movie Database"",
      ""Value"": ""7.6/10""
    },
    {
      ""Source"": ""Rotten Tomatoes"",
      ""Value"": ""92%""
    },
    {
      ""Source"": ""Metacritic"",
      ""Value"": ""86/100""
    }
  ],
  ""Metascore"": ""86"",
  ""imdbRating"": ""7.6"",
  ""imdbVotes"": ""445,001"",
  ""imdbID"": ""tt3890160"",
  ""Type"": ""movie"",
  ""DVD"": ""10 Jul 2017"",
  ""BoxOffice"": ""$107,825,862"",
  ""Production"": ""Working Title Films, Big Talk Pictures"",
  ""Website"": ""N/A"",
  ""Response"": ""True""
}";

            var movieService = new MovieService(null);

            var movie = movieService.FileToObject(jsonString);

            Assert.NotNull(movie);
            Assert.Equal("Baby Driver", movie.Title);
            Assert.Equal(new DateTime(2017, 06, 28), movie.Released);
            Assert.Equal(113, movie.RuntimeInMinutes);

        }
    }
}
