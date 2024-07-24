using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheaterApp.Models;
using TheatreApp.Web.Data;
using TheatreApp.Web.Models.DTOs.MoviesDTOs;

namespace TheatreApp.Web.Controllers
{
    [Route("api/movies")]
    [Authorize]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            var movieDto = new MovieDto
            {
                MovieID = movie.MovieID,
                MovieTitle = movie.MovieTitle,
                ImdbRating = movie.ImdbRating,
                YearReleased = movie.YearReleased,
                Budget = movie.Budget,
                BoxOffice = movie.BoxOffice,
                Language = movie.Language,
                AuthorID = movie.AuthorID,
                MovieAuthors = movie.MovieAuthors.ToList()
            };

            return Ok(movieDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieDto createMovieDto)
        {
            var movie = new Movie
            {
                MovieTitle = createMovieDto.MovieTitle,
                ImdbRating = createMovieDto.ImdbRating,
                YearReleased = createMovieDto.YearReleased,
                Budget = createMovieDto.Budget,
                BoxOffice = createMovieDto.BoxOffice,
                Language = createMovieDto.Language,
                AuthorID = createMovieDto.AuthorID
            };

            await _movieRepository.AddAsync(movie);

            return Ok(movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, UpdateMovieDto updateMovieDto)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.MovieTitle = updateMovieDto.MovieTitle;
            movie.ImdbRating = updateMovieDto.ImdbRating;
            movie.YearReleased = updateMovieDto.YearReleased;
            movie.Budget = updateMovieDto.Budget;
            movie.BoxOffice = updateMovieDto.BoxOffice;
            movie.Language = updateMovieDto.Language;
            movie.AuthorID = updateMovieDto.AuthorID;

            await _movieRepository.UpdateAsync(movie);

            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieRepository.DeleteAsync(id);
            return Ok(new { message = "Movie deleted successfully." });
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieRepository.GetAllAsync();
            if (movies == null || !movies.Any())
            {
                return NotFound();
            }

            var movieDtos = movies.Select(movie => new MovieDto
            {
                MovieID = movie.MovieID,
                MovieTitle = movie.MovieTitle,
                ImdbRating = movie.ImdbRating,
                YearReleased = movie.YearReleased,
                Budget = movie.Budget,
                BoxOffice = movie.BoxOffice,
                Language = movie.Language,
                AuthorID = movie.AuthorID,
                MovieAuthors = movie.MovieAuthors.ToList()
            }).ToList();

            return Ok(movieDtos);
        }


    }
}
