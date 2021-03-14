using System;

namespace Malcaba.MovieCollector.Data.Models
{
    public class History
    {
        public Guid Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public DateTime DateWatched { get; set; }
    }
}
