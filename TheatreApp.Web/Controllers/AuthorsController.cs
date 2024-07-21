using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using TheatreApp.Web.Data;
using TheatreApp.Web.Models.DTOs.AuthorsDTOs;

namespace TheatreApp.Web.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            var authorDto = new AuthorDto
            {
                AuthorID = author.AuthorID,
                AuthorName = author.AuthorName,
                MovieAuthors = author.MovieAuthors.ToList()
            };

            return Ok(authorDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = new Author
            {
                AuthorName = createAuthorDto.AuthorName
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return Ok(author);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorDto updateAuthorDto)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            author.AuthorName = updateAuthorDto.AuthorName;

            _context.Authors.Update(author);
            await _context.SaveChangesAsync();

            return Ok(author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
