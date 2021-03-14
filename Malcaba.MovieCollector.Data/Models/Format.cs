using System.Collections.Generic;

namespace Malcaba.MovieCollector.Data.Models
{
    public partial class Format
    {
        public Format()
        {
            Movie = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movie { get; set; }
    }
}
