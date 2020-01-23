using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmoteka.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime releaseDate { get; set; }
        public string genre { get; set; }
        public decimal price { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}