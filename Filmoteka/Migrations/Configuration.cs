namespace Filmoteka.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Filmoteka.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Filmoteka.Models.MovieDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Filmoteka.Models.MovieDBContext";
        }

        protected override void Seed(Filmoteka.Models.MovieDBContext context)
        {
            context.Genres.AddOrUpdate(j => j.name,
                new Genre
                {
                    name = "Action",
                },
                new Genre
                {
                    name = "Comedy",
                },
                new Genre
                {
                    name = "Crime",
                },
                new Genre
                {
                    name = "Drama",
                },
                new Genre
                {
                    name = "Fantasy",
                },
                new Genre
                {
                    name = "Historical",
                },
                new Genre
                {
                    name = "Horror",
                },
                new Genre
                {
                    name = "Sci-Fi",
                },
                new Genre
                {
                    name = "Thriller",
                },
                new Genre
                {
                    name = "Western",
                },
                new Genre
                {
                    name = "Other",
                }
            );
            context.Movies.AddOrUpdate(i => i.title,
                new Movie
                {
                    title = "Twelwe Monkeys",
                    releaseDate = DateTime.Parse("1985-12-8"),
                    genreFK = 8,
                    director = "Terry William"
                },
                new Movie
                {
                    title = "Inception",
                    releaseDate = DateTime.Parse("2010-7-22"),
                    genreFK = 8,
                    director = "Christopher Nolan"
                },
                new Movie
                {
                    title = "Interstellar",
                    releaseDate = DateTime.Parse("2014-11-06"),
                    genreFK = 8,
                    director = "Christopher Nolan"
                },
                new Movie
                {
                    title = "Blade Runner",
                    releaseDate = DateTime.Parse("1982-6-25"),
                    genreFK = 8,
                    director = "Ridley Scott",
                },
                new Movie
                {
                    title = "Inception",
                    releaseDate = DateTime.Parse("2010-7-22"),
                    genreFK = 8,
                    director = "Christopher Nolan"
                },
                new Movie
                {
                    title = "Se7en",
                    releaseDate = DateTime.Parse("1996-3-28"),
                    genreFK = 9,
                    director = "David Fincher",
                },
                new Movie
                {
                    title = "Django Unchained",
                    releaseDate = DateTime.Parse("2013-1-17"),
                    genreFK = 10,
                    director = "Qeuntin Tarantino",
                }

            );
            
        }
    }
}
