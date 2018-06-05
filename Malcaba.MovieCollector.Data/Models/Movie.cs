using System;
using System.Collections.Generic;

namespace Malcaba.MovieCollector.Data.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FormatId { get; set; }

        public Format Format { get; set; }
    }
}
