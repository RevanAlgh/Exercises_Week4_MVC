using TheaterApp.Models;
using TheatreApp.Web.Models.DTOs.MoviesDTOs;

namespace TheatreApp.Web.Data
{
    public interface IMovieRepository
    {
        Task<Movie> GetByIdAsync(int id);
        Task<IEnumerable<Movie>> GetAllAsync();
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(int id);
    }
}
