using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Filmoteka.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmoteka.Models
{
    public class Movie
    {
        public int id { get; set; }

        [Display(Name = "Název")]
        public string title { get; set; }

        [Display(Name = "Datum vydání")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime releaseDate { get; set; }
        /*
        [Display(Name = "Žánr")]
        public string genre { get; set; }
        */
        public int genreFK { get; set; }
        [Display(Name = "Žánr")]
        public Genre genre { get; set; }
        

        [Display(Name = "Režie")]
        public string director { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}