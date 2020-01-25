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
            context.Movies.AddOrUpdate(i => i.title,
                new Movie
                {
                    title = "Twelwe Monkeys",
                    releaseDate = DateTime.Parse("1985-12-8"),
                    genre = "Sci-Fi",
                    director = "Terry William",
                    price = 1.0M
                },
                new Movie
                {
                    title = "Inception",
                    releaseDate = DateTime.Parse("2010-7-22"),
                    genre = "Sci-Fi",
                    director = "Christopher Nolan",
                    price = 2.0M
                },
                new Movie
                {
                    title = "Interstellar",
                    releaseDate = DateTime.Parse("2014-11-06"),
                    genre = "Sci-Fi",
                    director = "Christopher Nolan",
                    price = 3.0M
                },
                new Movie
                {
                    title = "Blade Runner",
                    releaseDate = DateTime.Parse("1982-6-25"),
                    director = "Ridley Scott",
                    genre = "Sci-Fi",
                    price = 4.0M
                },
                new Movie
                {
                    title = "Inception",
                    releaseDate = DateTime.Parse("2010-7-22"),
                    director = "Christopher Nolan",
                    genre = "Sci-Fi",
                    price = 2.0M
                },
                new Movie
                {
                    title = "Se7en",
                    releaseDate = DateTime.Parse("1996-3-28"),
                    director = "David Fincher",
                    genre = "Thriller",
                    price = 10M
                },
                new Movie
                {
                    title = "Django Unchained",
                    releaseDate = DateTime.Parse("2013-1-17"),
                    genre = "Western",
                    director = "Qeuntin Tarantino",
                    price = 11M
                }
            );
        }
    }
}
