using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using TheatreApp.Web.Models.DTOs.AuthorsDTOs;

namespace TheatreApp.Web.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.Include(a => a.MovieAuthors).FirstOrDefaultAsync(a => a.AuthorID == id);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.Include(a => a.MovieAuthors).ToListAsync();
        }

        public async Task AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var author = await GetByIdAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }
    }
}
