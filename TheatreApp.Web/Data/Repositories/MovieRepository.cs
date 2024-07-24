using Microsoft.EntityFrameworkCore;
using TheaterApp.Models;
using TheatreApp.Web.Models.DTOs.MoviesDTOs;

namespace TheatreApp.Web.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.Include(m => m.MovieAuthors).FirstOrDefaultAsync(m => m.MovieID == id);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.Include(m => m.MovieAuthors).ToListAsync();
        }

        public async Task AddAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await GetByIdAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
