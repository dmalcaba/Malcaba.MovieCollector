using Malcaba.MovieCollector.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Malcaba.MovieCollector.Tests
{
    public class MovieServiceTests
    {

        [Theory]
        [InlineData("The Terminator", "Terminator, The")]
        [InlineData("A Terminator", "Terminator, A")]
        [InlineData("Terminator", "Terminator")]

        public void DetermineSortTitleTests(string title, string expected)
        {
            var movieService = new MovieService(null);

            var result = movieService.DetermineSortTitle(title);

            Assert.Equal(expected, result);
        
        }
    }
}
