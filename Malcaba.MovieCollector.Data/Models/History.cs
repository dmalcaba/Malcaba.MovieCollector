using System;
using System.Collections.Generic;
using System.Text;

namespace Malcaba.MovieCollector.Data.Models
{
    public class History
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public DateTime DateWatched { get; set; }
    }
}
