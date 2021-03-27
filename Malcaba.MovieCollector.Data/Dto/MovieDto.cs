﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Malcaba.MovieCollector.Data.Dto
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Rated { get; set; }
        public DateTime Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string ImdbID { get; set; }
        public int RuntimeInMinutes => int.TryParse(Runtime?.Split(' ')[0], out int result) ? result : 0;

    }
}
