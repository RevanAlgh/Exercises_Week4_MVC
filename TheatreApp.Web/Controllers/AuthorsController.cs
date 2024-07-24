using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using TheatreApp.Web.Data;
using TheatreApp.Web.Models.DTOs.AuthorsDTOs;

namespace TheatreApp.Web.Controllers
{
    [Route("api/authors")]
    [Authorize]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
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

            await _authorRepository.AddAsync(author);

            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, UpdateAuthorDto updateAuthorDto)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            author.AuthorName = updateAuthorDto.AuthorName;

            await _authorRepository.UpdateAsync(author);

            return Ok(author);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorRepository.DeleteAsync(id);
            return Ok(new { message = "Author deleted successfully." });
        }


        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorRepository.GetAllAsync();
            if (authors == null || !authors.Any())
            {
                return NotFound();
            }

            var authorDtos = authors.Select(author => new AuthorDto
            {
                AuthorID = author.AuthorID,
                AuthorName = author.AuthorName,
                MovieAuthors = author.MovieAuthors.ToList()
            }).ToList();

            return Ok(authorDtos);
        }

    }
}
