using MovieApi.Models;
using TheatreApp.Web.Models.DTOs.AuthorsDTOs;

namespace TheatreApp.Web.Data
{
    public interface IAuthorRepository
    {
        Task<Author> GetByIdAsync(int id);
        Task<IEnumerable<Author>> GetAllAsync();
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
    }
}
