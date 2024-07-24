using TheaterApp.Models;
using TheatreApp.Web.Data;

namespace TheatreApp.Web.Areas.Identity.Data.Reposirories
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
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> GetMoviesAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
