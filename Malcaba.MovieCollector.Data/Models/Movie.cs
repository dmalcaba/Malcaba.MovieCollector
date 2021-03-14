using System;

namespace Malcaba.MovieCollector.Data.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public int RunTime { get; set; }
        public string Plot { get; set; }
        public int FormatId { get; set; }
        public int RateId { get; set; }


        public Format Format { get; set; }
        public Rate Rate { get; set; }
    }
}
