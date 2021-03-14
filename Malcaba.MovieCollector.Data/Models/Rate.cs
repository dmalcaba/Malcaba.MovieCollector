using System.Collections.Generic;

namespace Malcaba.MovieCollector.Data.Models
{
    public class Rate
    {
        public Rate()
        {
            Movie = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movie { get; set; }
    }
}
