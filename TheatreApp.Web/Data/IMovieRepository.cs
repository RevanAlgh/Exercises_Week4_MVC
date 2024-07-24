using TheaterApp.Models;

namespace TheatreApp.Web.Areas.Identity.Data
{
    public interface IMovieRepository
    {
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> GetMoviesAsync(int id);
    }
}
