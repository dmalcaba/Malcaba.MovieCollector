using System;

namespace Malcaba.MovieCollector.Data.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleSort { get; set; }
        public DateTime Released { get; set; }
        public int RunTime { get; set; }
        public string Plot { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Poster { get; set; }
        public string ImdbID { get; set; }

        public string Collection { get; set; }
        public bool FullScreen { get; set; }
        public bool Dolby { get; set; }
        public int FormatId { get; set; }
        public int RateId { get; set; }
        

        public Format Format { get; set; }
        public Rate Rate { get; set; }
    }
}
