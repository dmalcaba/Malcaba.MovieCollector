using System;
using System.Collections.Generic;
using System.Text;

namespace Malcaba.MovieCollector.Data.Models
{
    public class Rate
    {
        public Rate()
        {
            Movie = new HashSet<Movie>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movie { get; set; }
    }
}
