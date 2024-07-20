using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using TheaterApp.Models;
using TheatreApp.Web.Data;

namespace TheatreApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movies = await _context.Movies.Include(m => m.MovieAuthors)
                                              .ThenInclude(ma => ma.Author)
                                              .ToListAsync();
            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var movie = await _context.Movies.Include(m => m.MovieAuthors)
                                             .ThenInclude(ma => ma.Author)
                                             .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "AuthorName");
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieID,MovieTitle,ImdbRating,YearReleased,Budget,BoxOffice,Language,AuthorID")] Movie movie, int authorID)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();

                if (authorID != 0)
                {
                    _context.MovieAuthors.Add(new MovieAuthor { MovieID = movie.MovieID, AuthorID = authorID });
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "AuthorName");
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var movie = await _context.Movies.Include(m => m.MovieAuthors).ThenInclude(ma => ma.Author)
                                             .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "AuthorName");
            return View(movie);
        }

        // POST: Movies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie, int authorID)
        {
            if (id != movie.MovieID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(movie).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var movieAuthor = await _context.MovieAuthors.FirstOrDefaultAsync(ma => ma.MovieID == movie.MovieID);
                if (movieAuthor != null)
                {
                    _context.MovieAuthors.Remove(movieAuthor);
                    await _context.SaveChangesAsync();
                }

                if (authorID != 0)
                {
                    _context.MovieAuthors.Add(new MovieAuthor { MovieID = movie.MovieID, AuthorID = authorID });
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorID", "AuthorName");
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var movie = await _context.Movies.Include(m => m.MovieAuthors)
                                             .ThenInclude(ma => ma.Author)
                                             .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieID == id);
        }
    }
}
