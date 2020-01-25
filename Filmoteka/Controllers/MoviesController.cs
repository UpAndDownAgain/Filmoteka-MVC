using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Filmoteka.Models;


namespace Filmoteka.Controllers
{
    [RequireHttps]
    public class MoviesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Movies
        [AllowAnonymous]
        public ActionResult Index(string movieGenre, string searchString)
        { 
            var movieList = getMovieList();
            var genreList = getGenreList();

            ViewBag.movieGenre = new SelectList(genreList);

            
            foreach(var m in movieList)
            {
                m.genre = genreList.Find(x => x.id == m.genreFK);
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                
                movieList = movieList.FindAll(x => x.genre.name == movieGenre);

            }

            if (!string.IsNullOrEmpty(searchString))
            {
                movieList = movieList.FindAll(s => s.title.Contains(searchString));
            }
            return View(movieList);
        }

        // GET: Movies/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            movie.genre = getGenreList().Find(x => x.id == movie.genreFK);
            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Roles ="admin")]
        public ActionResult Create()
        {
            var genreList = getGenreList();

            ViewBag.movieGenre = new SelectList(genreList);
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create(string movieGenre, [Bind(Include = "id,title,releaseDate,genre,price,director")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                var genreList = getGenreList();
                movie.genreFK = genreList.Find(x => x.name.Equals(movieGenre)).id;
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            var genreList = getGenreList();
            ViewBag.movieGenre = new SelectList(genreList);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            //ViewBag.genre = movie.genre.name;
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(string movieGenre, [Bind(Include = "id,title,releaseDate,genre,price,director")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                var genreList = getGenreList();
                movie.genreFK = genreList.Find(x => x.name.Equals(movieGenre)).id;
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Filmy/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Filmy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        protected List<Genre> getGenreList()
        {
            var genreList = new List<Genre>();
            var genreQuery = from d in db.Genres orderby d.id select d;
            genreList.AddRange(genreQuery);
            return genreList;
        }

        protected List<Movie> getMovieList()
        {
            var movieList = new List<Movie>();
            var movieQuery = from m in db.Movies orderby m.title select m;
            movieList.AddRange(movieQuery);
            return movieList;
        }
    }
}
